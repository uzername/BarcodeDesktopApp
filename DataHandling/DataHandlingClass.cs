using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BarcodeDesktopApp.DataHandling
{
    [Serializable]
    public class DataHandlingConfig
    {
        
        public string pathToDatabase;
    }
    public class DbFilterStruct  {
        // complex filters
        public string truckFilter;
        public string deliveryDateFilter;
        // simple filters
        public string partNumberFilter;
        public string machineFilter;
        public string customerFilter;

    }

    public class DataHandlingClass  {
        private String pathToConfigFile = "config.xml";

        public DataHandlingConfig newconfig;
        public List<BarcodePartDataClass> allPartsList = new List<BarcodePartDataClass>();

        private static String barcodePartTableDef = "create table Barcodes (" +
            "ID INTEGER PRIMARY KEY," +
            "ID_part INTEGER NOT NULL," +
            "BarcodeDate TEXT DEFAULT NULL," +
            "BarcodeTruck INT NOT NULL," +
            "BarcodeMachine TEXT DEFAULT NULL," +
            "BarcodeCustomer TEXT DEFAULT NULL," +
            "BarcodeDateAdded TEXT NOT NULL," +
            "FOREIGN KEY (ID_part) references Parts(ID)" +
            ")";

        private static String barcodePartTableDef2 = "create table Parts (" +
            "ID INTEGER PRIMARY KEY," +
            "Barcode TEXT NOT NULL UNIQUE," +
            "BarcodePart TEXT NOT NULL UNIQUE," +
            "BARCODETYPE Integer" +
            ")";

        public void getDataFromConfigFile()  {
            XmlSerializer formatter = new XmlSerializer(typeof(DataHandlingConfig));
            if (File.Exists(pathToConfigFile))  {
                using (FileStream fs = new FileStream(pathToConfigFile, FileMode.Open))  {
                    newconfig = (DataHandlingConfig)formatter.Deserialize(fs);                   
                }
            } else {
                newconfig = new DataHandlingConfig();
                newconfig.pathToDatabase = "barcodes.sqlite3";
                using (FileStream fs = new FileStream(pathToConfigFile, FileMode.Create))    {
                    formatter.Serialize(fs, newconfig);
                }
            }
        }

        /// <summary>
        /// START WITH THIS SUBROUTINE! check whether local sqlite db is available. if not then create it, add some user with full rights, else - exit method
        /// </summary>
        /// <param name="in_pathToDbFile"></param>
        /// <returns>true if db  file was not available and was recreated</returns>
        public bool checkDbAvailabilityAndRecreate(String in_pathToDbFile)
        {
            
            bool retvalue = !System.IO.File.Exists(in_pathToDbFile);
            // https://stackoverflow.com/questions/24178930/programmatically-create-sqlite-db-if-it-doesnt-exist
            if (retvalue)
            {
                // https://www.codeguru.com/csharp/.net/net_data/using-sqlite-in-a-c-application.html - execute query
                SQLiteConnection.CreateFile(in_pathToDbFile);
                SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + in_pathToDbFile + ";Pooling=True;Max Pool Size=100;");
                sql_con.Open();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sql_con.CreateCommand();
                sqlite_cmd.CommandText = barcodePartTableDef2;
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = barcodePartTableDef;
                sqlite_cmd.ExecuteNonQuery();                                
                sql_con.Close();
            }
            return retvalue;
        }
        // getBarcodesDataClass does not retrieve all parts. there may be parts which were not in production.
        public List<BarcodePartDataClass> getAllParts()
        {
            List<BarcodePartDataClass> rslt = new List<BarcodePartDataClass>();
            String dbquery = "Select * from Parts ";
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + newconfig.pathToDatabase);
            sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
            {
                cmd.CommandText = dbquery;
                SQLiteDataReader sqlite_datareader = cmd.ExecuteReader();
                while (sqlite_datareader.Read())  {
                    BarcodePartDataClass barcodePartData = new BarcodePartDataClass();
                    barcodePartData.ID = sqlite_datareader.GetInt32(0);
                    barcodePartData.BarcodeRaw = sqlite_datareader.GetString(1);
                    barcodePartData.BarcodePart = sqlite_datareader.GetString(2);
                    barcodePartData.BarcodeType = (BarcodeTypeEnum)sqlite_datareader.GetInt32(3);
                    rslt.Add(barcodePartData);
                }
            }
            sql_con.Close();
            return rslt;
        }

        public List<BarcodeDataClass> getBarcodesDataFromDataBase(DbFilterStruct filter)  {
            string condition = "";
            if (!((filter == null) || (String.IsNullOrEmpty( filter.customerFilter) && String.IsNullOrEmpty(filter.deliveryDateFilter) && 
                                     String.IsNullOrEmpty(filter.machineFilter) && String.IsNullOrEmpty(filter.partNumberFilter) && 
                                     String.IsNullOrEmpty(filter.truckFilter)) ))
            {
                bool usedValue = false;
                condition = " WHERE (";
                if (String.IsNullOrEmpty(filter.partNumberFilter) == false)  {
                    condition += "(BarcodePart = @BarcodePartP )";
                    usedValue = true;
                }
                if (String.IsNullOrEmpty(filter.deliveryDateFilter))
                {
                    if (usedValue) { condition += " AND "; }
                    condition += "( BarcodeDate  = @BarcodeDateP )";
                    usedValue = true;
                }
                if (String.IsNullOrEmpty(filter.truckFilter) == false)     {
                    if (usedValue) { condition += " AND "; }
                    condition += "(BarcodeTruck = @BarcodeTruckP) ";
                    usedValue = true;
                }
                if (String.IsNullOrEmpty(filter.machineFilter) == false)   {
                    if (usedValue) { condition += " AND "; }
                    condition += "(BarcodeMachine = @BarcodeMachineP) ";
                    usedValue = true;
                }
                if (String.IsNullOrEmpty(filter.customerFilter) == false)
                {
                    if (usedValue) { condition += " AND "; }
                    condition += "(BarcodeCustomer = @BarcodeCustomerP) ";
                    usedValue = true;
                }
                condition += ")";

            }
            List<BarcodeDataClass> rslt = new List<BarcodeDataClass>();
            String dbquery = "Select * from Barcodes inner join Parts on Barcodes.ID_part = Parts.ID " + condition;
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + newconfig.pathToDatabase);
            sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
            {
                cmd.CommandText = dbquery;
                //fill up parameters
                if (condition!="")  {
                    if (String.IsNullOrEmpty(filter.partNumberFilter) == false)
                        cmd.Parameters.AddWithValue("@BarcodePartP", filter.partNumberFilter);
                    if (String.IsNullOrEmpty(filter.deliveryDateFilter) == false)
                        cmd.Parameters.AddWithValue("@BarcodeDateP", filter.deliveryDateFilter);
                    if (String.IsNullOrEmpty(filter.truckFilter) == false)
                        cmd.Parameters.AddWithValue("@BarcodeTruckP", filter.truckFilter);
                    if (String.IsNullOrEmpty(filter.machineFilter) == false)
                        cmd.Parameters.AddWithValue("@BarcodeMachineP", filter.machineFilter);
                    if (String.IsNullOrEmpty(filter.customerFilter) == false)
                        cmd.Parameters.AddWithValue("@BarcodeCustomerP", filter.customerFilter);
                }
                SQLiteDataReader sqlite_datareader = cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string RPart_ = sqlite_datareader.GetString(1);
                    DateTime RDate_ = sqlite_datareader.GetDateTime(2);
                    int RTruck_ = sqlite_datareader.GetInt32(3);
                    string RMachine_ = sqlite_datareader.GetString(4);
                    string RCustomer_ = sqlite_datareader.GetString(5);

                    BarcodeDataClass barcodeData = new BarcodeDataClass { BarcodePart = RPart_, BarcodeDate = RDate_, BarcodeTruck = RTruck_, BarcodeMachine = RMachine_, BarcodeCustomer = RCustomer_ };
                    rslt.Add(barcodeData);
                }
            }
            sql_con.Close();
            return rslt;

        }
        /// <summary>
        /// Add new entry to list of parts. Or find its ID if this entry already exists
        /// </summary>
        /// <param name="in_newPart"></param>
        /// <param name="in_rawGenValue"></param>
        /// <param name="in_barcodeType"></param>
        public int insertNewEntryToPartsList(String in_newPart, String in_rawGenValue, ref bool entryAdded, BarcodeTypeEnum in_barcodeType = BarcodeTypeEnum.EAN13)
        {
            int IDwasAdded = -1;
            entryAdded = true;
            String dbquerySelect = "Select ID from Parts where BarcodePart = @inPartName";
            String dbqueryInsert = "Insert into Parts(Barcode, BarcodePart, BARCODETYPE) VALUES (@in_NewBarcode, @in_BarcodePart, @in_BarcodeType)";
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + newconfig.pathToDatabase);
            sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
            {
                cmd.CommandText = dbquerySelect;
                cmd.Parameters.AddWithValue("@inPartName", in_newPart);
                long? foundID = (long?)cmd.ExecuteScalar();
                if (foundID != null)  {
                    IDwasAdded = (int)foundID.Value;
                    entryAdded = false;
                } else {
                    cmd.CommandText = dbqueryInsert;
                    cmd.Parameters.AddWithValue("@in_NewBarcode", in_rawGenValue);
                    cmd.Parameters.AddWithValue("@in_BarcodePart", in_newPart);
                    cmd.Parameters.AddWithValue("@in_BarcodeType", in_barcodeType);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = dbquerySelect;
                    cmd.Parameters.AddWithValue("@inPartName", in_newPart);
                    long? foundID2 = (long?)cmd.ExecuteScalar();
                    if (foundID2 != null)  {
                        IDwasAdded =(int) foundID2.Value;
                    }

                }
            }
            sql_con.Close();
            return IDwasAdded;
        }

        // Generate a random string with a given size  
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(10 * random.NextDouble() + 48)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public String generateNewBarcodeNumeric(BarcodeTypeEnum in_barcodeType = BarcodeTypeEnum.EAN13)
        {
            String valueToReturn = "";
            List<String> allStringies = new List<string>();
            String dbQuery = "Select Barcode from Parts WHERE BARCODETYPE = @BarcodeTypeIn";
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + newconfig.pathToDatabase);
            sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
            {
                cmd.CommandText = dbQuery;
                cmd.Parameters.AddWithValue("@BarcodeTypeIn", (int)in_barcodeType);
                SQLiteDataReader sqlite_datareader = cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string RCode_ = sqlite_datareader.GetString(0);
                    allStringies.Add(RCode_);
                }
            }
            bool valueGenerated = false;
            do {
                valueToReturn = this.RandomString(12);
                valueGenerated = !(allStringies.Contains(valueToReturn));
            } while (!valueGenerated);
            sql_con.Close();
            return valueToReturn;
        }

    }
}
