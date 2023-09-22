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
            PopulateDriveComboBox();




        }
        private void PopulateDriveComboBox()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    DriveComboBox.Items.Add(drive.Name);
                }
            }

            if (DriveComboBox.Items.Count > 0)
            {
                DriveComboBox.SelectedIndex = 0; // Optionally, select the first drive by default.
            }
            else
            {
                DriveComboBox.Items.Add("No available drives");
                DriveComboBox.Enabled = false; // Disable the ComboBox if no drives are available.
            }
        }


        private void PopulateDatabaseComboBox()
        {




            string connectionString = "server=.;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;database=master;UID=sa;password=123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();



            try
            {


                SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE database_id >6 ORDER BY name desc;", connection);



                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string databaseName = reader["name"].ToString();
                            DatabaseComboBox.Items.Add(databaseName);


                        }

                        if (DatabaseComboBox.Items.Count > 0)
                        {
                            DatabaseComboBox.SelectedIndex = 0; // Optionally, select the first drive by default.
                        }
                        else
                        {
                            DatabaseComboBox.Items.Add("No Database available ");
                            DatabaseComboBox.Enabled = false; // Disable the ComboBox if no drives are available.
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
            string backupPath = DriveComboBox.SelectedItem.ToString();
            if (backupPath == null)
            {
                MessageBox.Show("No available drives found for backup.");
                return;
            }
            backupPath = Path.Combine(backupPath, "Backup");
            if (!Directory.Exists(backupPath))
            {
                try
                {
                    Directory.CreateDirectory(backupPath);
                    // MessageBox.Show("Folder created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                }
            }

            String db = DatabaseComboBox.SelectedItem.ToString();
            String Drv = DriveComboBox.SelectedItem.ToString();

            try
            {
                {
                    string backupQuery = $"BACKUP DATABASE {db} TO DISK = '{Drv}Backup\\{db}.bak' WITH INIT;";
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    command.ExecuteNonQuery();

                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show("Backup completed successfully.", title, buttons, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                        Form1 f1 = new Form1();
                        f1.Close();

                    }
                    else
                    {

                        button1.Focus();

                    }



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


            // Set the backup path here
            String Drv = DriveComboBox.SelectedItem.ToString();


            string backupPath = $"{Drv}";
           
            backupPath = Path.Combine(backupPath, "Backup");
            if (!Directory.Exists(backupPath))
            {
                try
                {
                    Directory.CreateDirectory(backupPath);
                    // MessageBox.Show("Folder created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                }
            }

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

        private void DatabaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}