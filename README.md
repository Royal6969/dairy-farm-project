🆕 To create this Windows Form Application, you have to set this options:
 - Language:C#
 - Platform: Windows
 - Type: Desktop

 Note: Make sure you have ".NET Desktop Development" extensions installed, and select the option:
 - Windows Forms App (.NET Framework) - A project for creating an application with a Windows Forms (WinForms) user interface

 ![NET Desktop](./img/readme/NET_desktop.png)
 ![WinsFormsApp](./img/readme/wfa.png)


 ⏱ ##To follow my commit changes
 - https://github.com/Royal6969/dairy-farm-project/commits/main


 👓 ##How to show toolbox and solution explorer and style properties in visual studio
 - https://www.youtube.com/watch?v=lms7X_b1-dY&ab_channel=TamtamQuinn


 🎨 ##For some UI components styles, I will use Bunifu Framework
  - It requires a paid license, but we can crack it...
  - https://docs2.bunifuframework.com/docs/getting-started/install
  - https://www.youtube.com/watch?v=1QZHT9by2xo&ab_channel=C%C3%B3digoLimpio

  I also installed Guna UI2 Framework, for other styles, and you can get it here (free trial)
  - https://www.nuget.org/packages/Guna.UI2.WinForms/
  or try to crack it too
  - https://www.youtube.com/watch?v=vJ7yB_pZ3a0


 📝 ##Basic structure to start
 We start with a form template that we rename to Splash.cs (preload screen),
 and after that, we create the Login.cs (login screen) adding a new class element (type Windows Forms)
 
 Tip: To see changes faster, change in Program.cs Application.Run(new Splash()) to Application.Run(new "component"()).

 ![0.Splash](./img/readme/0.splash.png)
 ![0.Login](./img/readme/0.login.png)
 
 #Let's start with the frontend, so we're going to design the pages (sections)

 ① Cows List (CRUD)

 ![1.Cows](./img/readme/1.cows.png)

 ② Milk Production

 ![2.Production](./img/readme/2.production.png)

 ③ Cows Health

 ![3.Health](./img/readme/3.health.png)

 ④ Cows Breeding

  ![4.Breeding](./img/readme/4.breeding.png)

  ⑤ Milk Sales

  ![5.Sales](./img/readme/5.sales.png)

  ⑥ Farm Finances

  ![6.finances](./img/readme/6.finances.png)

  ⑦ Dashboard

  ![7.Dashboard](./img/readme/7.dashboard.png)

  ## 🔗 Let's connect the different sections with sidebar links.
  To do that, in each section, in sidebar, we have to do double click in each sidebar button (in link names),
  and code in .cs will open, the label method exactly.
  And you just have to write something like this:
  
  private void label5_Click(object sender, EventArgs e)
  {
    Cows Ob = new Cows();
    Ob.Show();
    this.Hide();
  }

  In this case, the label button section in sidebar pressed was Cows.

  ## 📚 Time to install SQL Server Express for database (basic features)

  https://www.microsoft.com/en-us/sql-server/sql-server-downloads

  ![installing-sql-server-express](./img/readme/install-sql-server.png)

  ## 💼 Install Microsoft SQL Management Studio

  https://docs.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15

  ![installing-sql-server-management-studio](./img/readme/sql-management-studio.png)

  ## 🔌 Connect to your new SQL server and create de database
  
    1. In VS, press View in toolbox and select "Server explorer"
    2. Press teh button "Connect with database"
    3. Write the name of server provided by SQL Server Management Studio and the new database name
    4. Confirm that doesn't exists and you want to create it

  ![sql-server-name](./img/readme/sql-name-server.png)
  ![add-server-create-db](./img/readme/create-database.png)
  ![db-created-server-explorer](./img/readme/database-created.png)


  ## 📋 Create the tables for the database

  Press right click in "Tables" to add new one, 
  and add all fields you need, with the name, data type, no nulls...
  
  Tip: use the default id and rename it to use it as PK, or right click in one field to make it primary key

  After all, you have to "update" the table (remember to press the "refresh" button in Server Explorer)

  ![add-new-table](./img/readme/add-new-table.png)
  ![update-the-table](./img/readme/updating-new-table.png)

  ① Milk Production Table

  ![production-table](./img/readme/milk-table.png)

  ② Cows Table

  ![cow-table](./img/readme/cow-table.png)

  ③ Employees Table

  ![employee-table](./img/readme/employee-table.png)

  ④ Health Table

  ![health-table](./img/readme/health-table.png)

  ⑤ Sales Table

  ![sales-table](./img/readme/sales-table.png)

  ⑥ Expenditure Table

  ![expenditure-table](./img/readme/expenditure-table.png)

  ⑦ Income Table

  ![income-table](./img/readme/income-table.png)

  ⑧ Breeding Table

  ![breeding-table](./img/readme/breed-table.png)

  Now we just need to connect the tables among them with foreign keys,
  but we will get it continuing the project development and throughout code all sections...
  
  👨‍💻 Let's start coding the Backend !!

  Let's start coding Cows section.
  
  In each field properties, set a (Name).
  Then, double click in a button for example, to go to code class.
  Import (using) System.Data.SqlClient;
  
  If in Server Explorer view, you press right click in your connection,
  and press in properties, you will see in Properties view the "connection statement",
  and you have to copy that, to paste it in this sentence:
  
  SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");

  In the properties view of datepicker, look for the property ValueChange and do double click to autogenerate its function.
  Repeat it with the property MouseLeave.
  We need to calculate the age from the datepicker date...

  ![ValueChange](./img/readme/DOBDate_ValueChanged.png)
  ![MouseLeave](./img/readme/DOBDate_MouseLeave.png)

  ```csharp
        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            MessageBox.Show("" + age);
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }
  ```

  Now, we have to do double click in save button to generate the save function and code it:

  ```csharp
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into CowTbl (CowName, EarTag, Color, Breed, Age, WeightAtBirth, Pasture) values ('"+ CowNameTb.Text +"', '" + EarTagTb.Text + "', '" + ColorTb.Text + "', '" + BreedTb.Text + "', "+ age +", '" + WeightTb.Text + "', '" + PastureTb.Text +"')"; // It's very important to write the same numbers of fields and values ... // https://es.stackoverflow.com/questions/115201/alguna-forma-de-insertar-registros-cuando-la-tabla-tiene-default-e-identity-en
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow save successfully");

                    Con.Close();

                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
  ```

  ![cow-saved-button](./img/readme/cow-saved-button.png)

  It works perfectly !! Let's take a look to the data saved.
  In server explorer view, if you do right click in a table, you can press the option "view data table"

  ![cow-saved-data](./img/readme/cow-saved-data.png)

