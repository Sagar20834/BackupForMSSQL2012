namespace Backup

{
    using Microsoft.Data.SqlClient;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.IO;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BackupUserDatabases(string backupPath)
        {
            ServerConnection serverConnection = new ServerConnection(".");
            Server server = new Server(serverConnection);

            // Iterate over each database and backup user-created databases
            foreach (Database database in server.Databases)
            {
                if (!database.IsSystemObject)
                {
                    Backup backup = new Backup();
                    backup.Action = BackupActionType.Database;
                    backup.Database = database.Name;

                    // Set the backup path and filename
                    string backupFileName = $"{backupPath}\\{database.Name}.bak";
                    backup.Devices.AddDevice(backupFileName, DeviceType.File);

                    backup.Initialize = true;
                    backup.Checksum = true;
                    backup.ContinueAfterError = true;

                    // Perform the backup
                    backup.SqlBackup(server);
                }
            }

            serverConnection.Disconnect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDatabaseComboBox();
            string drive = "D:" ; // Replace with the desired drive letter
            string folderName = "Backup";

            string path = Path.Combine(drive, folderName);

            if (Directory.Exists(path))
            {

            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                   // MessageBox.Show("Folder created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                }
            }


        }

        private void PopulateDatabaseComboBox()
        {




            string connectionString = "server=.;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;database=master;UID=sa;password=123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();



            try
            {


                SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4 AND name != 'ReportServer' AND name != 'ReportServerTempDB' ORDER BY name;", connection);



                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string databaseName = reader["name"].ToString();
                            DatabaseComboBox.Items.Add(databaseName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving databases: {ex.Message}");
                Console.Write($"An error occurred while retrieving databases: {ex.Message}");


            }
            connection.Close();
        }
        private void takebackup(object sender, EventArgs e)
        {


            string connectionString = "server=.;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;database=master;UID=sa;password=123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            String db = DatabaseComboBox.SelectedItem.ToString();

            try
            {
                {
                    string backupQuery = $"BACKUP DATABASE {db} TO DISK = 'D:\\Backup\\{db}.bak';";
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Backup completed successfully.");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving databases: {ex.Message}");


            }
            connection.Close();
        }

        private void takebackupall(object sender, EventArgs e)
        {


            string backupPath = "D:\\Backup"; // Set the backup path here

            try
            {
                BackupUserDatabases(backupPath);
                MessageBox.Show("Backup completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during backup: {ex.Message}");
            }


        }


    }
}