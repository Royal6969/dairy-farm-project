🆕 To create this Windows Form Application, you have to set this options:
 - Language:C#
 - Platform: Windows
 - Type: Desktop

 Note: Make sure you have ".NET Desktop Development" extensions installed, and select the option:
 - Windows Forms App (.NET Framework) - A project for creating an application with a Windows Forms (WinForms) user interface

 ![NET Desktop](./img/readme/NET_desktop.png)
 ![WinsFormsApp](./img/readme/wfa.png)


 ⏱ ## To follow my commit changes
 - https://github.com/Royal6969/dairy-farm-project/commits/main


 👓 ## How to show toolbox and solution explorer and style properties in visual studio
 - https://www.youtube.com/watch?v=lms7X_b1-dY&ab_channel=TamtamQuinn


 🎨 ## For some UI components styles, I will use Bunifu Framework
  - It requires a paid license, but we can crack it...
  - https://docs2.bunifuframework.com/docs/getting-started/install
  - https://www.youtube.com/watch?v=1QZHT9by2xo&ab_channel=C%C3%B3digoLimpio

  I also installed Guna UI2 Framework, for other styles, and you can get it here (free trial)
  - https://www.nuget.org/packages/Guna.UI2.WinForms/
  or try to crack it too
  - https://www.youtube.com/watch?v=vJ7yB_pZ3a0


 📝 ## Basic structure to start
 We start with a form template that we rename to Splash.cs (preload screen),
 and after that, we create the Login.cs (login screen) adding a new class element (type Windows Forms)
 
 Tip: To see changes faster, change in Program.cs Application.Run(new Splash()) to Application.Run(new "component"()).

 ![0.Splash](./img/readme/0.splash.png)
 ![0.Login](./img/readme/0.login.png)
 
 # Let's start with the frontend, so we're going to design the pages (sections)

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
  
  # 👨‍💻 Let's start coding the Backend !!

  ## ① Cow Module 🐄
  
  In each field properties, set a (Name).
  Then, double click in a button for example, to go to code class.
  Import (using) System.Data.SqlClient;
  
  If in Server Explorer view, you press right click in your connection,
  and press in properties, you will see in Properties view the "connection statement",
  and you have to copy that, to paste it in this sentence:
  
  ```csharp
  SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");
  ```

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

  Now, we have to display tables in the dataGrid view.

  You have to change the property (name) for DataGridView,
  and create the typical populate function.
  Once we have it, set it in the initializer class method.

  ```csharp
        private void populate()
        {
            Con.Open();

            string query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
  ```
  
  ![cow-list-working](./img/readme/cow-list-works.png)

  To can edit data in dataGridView, we need to develop its function:
  
  ```csharp
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowsDGV.SelectedRows[0].Cells[4].Value.ToString();

            if(CowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[5].Value.ToString());
            }

            WeightTb.Text = CowsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PastureTb.Text = CowsDGV.SelectedRows[0].Cells[7].Value.ToString();
        }
  ```

  And to delete a cow object, it's looks like Save button code:

  ```csharp
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the cow to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "delete from CowTbl where CowId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow deleted successfully");

                    Con.Close();
                    populate();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
  ```

  Finally, for Edit button, it's the same code like Save button, but just changing the query string:

  ```csharp
  string Query = "update CowTbl set CowName='"+ CowNameTb.Text +"', EarTag='"+ EarTagTb.Text +"', Color='"+ ColorTb.Text +"', Breed='"+ BreedTb.Text +"', Age='"+ age +"', WeightAtBirth='"+ WeightTb.Text +"', Pasture='"+ PastureTb.Text +"' where CowId="+ key +";";
  ```

  ## ② Production Module 🥛

  We have to repeat part of proccess before...
  In Program.cs change to Application.Run(new Production()),
  in Production.cs(design) change (Name) field for differents buttons...

  And now, let's fill the CowId comboBox with CowTbl table,
  and for that, we have to copy/paste the same SqlConnection that we used in Cow module,
  and create the fillCowId() method and place it in the initializer method:

  ```csharp
        private void fillCowId()
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;

            Con.Close();
        }
  ```

  Populate() function is the same too, just changing the table,
  also, Clear() function it's the same but changing the fields names.

  Now, whenever a cow Id id selected, it's name should be displayed in CowNameTb
  Note: CowName field has to be not enabled (false)

  ```csharp
        private void GetCowName()
        {
            Con.Open();

            string query = "select * from CowTbl where CowId="+ CowIdCb.SelectedValue.ToString() +"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach(DataRow dr in dt.Rows)
                CowNameTb.Text = dr["CowName"].ToString();

            Con.Close();
        }
  ```

  For Save button we change the fields we check in if() sentence,
  and now, we have to auto-generate a special function that you will find in properties:

  ![selection-change-committed](./img/readme/selection-change-committed.png)

  ```csharp
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AmTb.Text == "" || NoonTb.Text == "" || PmTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into MilkTbl (CowId, CowName, AmMilk, NoonMilk, PmMilk, TotalMilk, DateProd) values ("+ CowIdCb.SelectedValue.ToString() +", '" + CowNameTb.Text + "', '" + AmTb.Text + "', '" + NoonTb.Text + "', '" + PmTb.Text + "', '" + TotalTb.Text + "', '"+ DateTb.Value.Date +"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk saved successfully");

                    Con.Close();
                    populate();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
   ```

  Now, let's calculate automatically the total,
  and to do that, let's auto-generate the leave function for PmMilk field
  (look for that in properties)

  ![calculate-total-leave-function](./img/readme/pmMilk-leave.png)

  ```csharp
    private void PmTb_Leave(object sender, EventArgs e)
    {
        int total = Convert.ToInt32(AmTb.Text) + Convert.ToInt32(NoonTb.Text) + Convert.ToInt32(PmTb.Text);
        TotalTb.Text = "" + total;
    }
  ```

  ![test-production-module-1](./img/readme/test-production-module-1.png)

  ![test-production-module-2](./img/readme/test-production-module-2.png)

  To auto-fill fields selecting an object from DataGridView, 
  it's very similar to the same DGV function in Cows module, but changing the fields:
  
  ```csharp
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmTb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            NoonTb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateTb.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
  ```

  ## ④ Health Module 💊

    1. Go to Health module and delete the DataGridView, and better copy de DataGridView we made in Production module
    2. Change its (name) to HealthDGV, and change the other fields (names).
    3. Copy the sqlConnection sentence with fillCowId(), populate(), clear(), and GetCowName() functions. (import System.Data.SqlClient)
    4. Change words (Milk -> Health) in some sentences...
    5. Set the fillCowId() and populate() functions in the initializer method.
    6. Auto-generate CowIdCb_SelectionChangeCommittted() function, and insert inside it the GetCowName() function (also disable CowName field)
    7. Auto-generate save function doing double click in Save button, and copy/paste the Save button content we made in Production module, and change its fields.
    8. Auto-generate clear function doing double click in Clear button (I changed "update" to "clear"), and set the Clear() function we made before
    9. For DGV, copy/paste de function content in Production module and change the fields.
    10. Same process with delete function
    11. And once again, same process with edit function, copy content from Production module, double click in Edit button to auto-generate function, change fields...

  ## ⑤ Breeding Module 🍼

  You just have to follow the same steps but with one difference,
  you also need to get the cow age you are selecting, and to do that,
  simply add this sentence in the forEach() in GetCowName() function:

  ```csharp
  AgeTb.Text = dr["Age"].ToString();
  ```

  ## ⑥ Employees Module ‍💼

    1. Add a new element --> Form (Windows Forms)
    2. At first, remember... position (center screen), formBorderStyle (none), copy Cow module measures for paste in Employees module size,
    3. Copy all design from Health module to Employees module, and delete the sidebar content (sections links).
    4. Change the design, for example, removing some containers and replacing the others.
    5. Change fields (names) and its titles (text).
    6. Copy SqlConnection sentence and the populate() function from Health.cs for example (change some words, and set populate() function in the initializer method).
    7. Copy save function content from Production module for example, to save function in Employees module. (don't forget to refer to Gender as GenderCb.SelectedIndex in checks and as GenderCb.SelectedItem for its value)
    8. Copy DVG function content from Cows module for example, to select any employee in list.
    9. The Clear button with its clear function...
    10. Copy delete function content from Health module for example, to delete any employee.
    11. Copy edit function content from Cows module for example, to edit any employee.

  ![employee-design](./img/readme/employee.png)

  ## ⑦ Sales Module 💶

  Repeat same steps before to do this module,
  the only difference is you have to fetch data from Employee table,
  so be careful for the sentences affected !
  Don't forget the Quantity button leave function we made before... 

  ![sales-design](./img/readme/sales.png)

  ## ⑧ Finances Module 📈

  Once again, repeat the same steps before.
  Realize you have to do functoons x2 because you have two tables here.
  
  Another detail, when you have the income save funcion, copy/paste it in Sales module,
  because sales is an income finance operation.
  Whenever we sale milk, the operation should be stored in Income table.

  Now let's filter expenses and incomes by day.
  Just copy/paste populateIncomes() and populate Expenditures() functions and ...

  ```csharp
  string query = "select * from IncomeTbl where IncDate='" + IncDatePickerTb.Value.Date + "'";

  string query = "select * from ExpenditureTbl where ExpDate='" + ExpDatePickerTb.Value.Date + "'";
  ```

  And for refresh buttons, just add an image and click it to auto-generate its click function, and set its populate inside it.

  ![finances-design](./img/readme/finances.png)

  ## ⑨ Dashboard Module 📊

  Firstable, redesign it.
  Note: to gradient colors, look for "FillColor1" and "FillColor2" properties.

  In Finnace square, we have to calculate the finance panel.
  Copy/paste SqlConnection and create a funcyion to get (sum) IncAmt field in IncomeTbl.

  ```csharp
        private void Finance()
        {
            // we calculate the Finance related Analytics

            Con.Open();

            int inc, exp; 
            double bal;

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl", Con);
            
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            inc = Convert.ToInt32(dt1.Rows[0][0].ToString());
            IncLbl.Text = "Rs: " + dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            exp = Convert.ToInt32(dt2.Rows[0][0].ToString());
            ExpLbl.Text = "Rs: " + dt2.Rows[0][0].ToString();

            bal = inc - exp;
            BalLbl.Text = "Rs: " + bal;

            Con.Close();
        }
  ```

  We can do something similar for Logistic square and max values.

  ```csharp
        private void Logistic()
        {
            // we calculate the Logistics related Analytics

            Con.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from CowTbl", Con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            CowNumLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(TotalMilk) from MilkTbl", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            MilkLitersLbl.Text = dt2.Rows[0][0].ToString() + " liters";

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from EmployeeTbl", Con);

            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            EmpNumLbl.Text = dt3.Rows[0][0].ToString();

            Con.Close();
        }

        private void GetMax()
        {
            SqlDataAdapter sda1 = new SqlDataAdapter("select max(IncAmt) from IncomeTbl", Con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            HighSaleLbl.Text = "Rs: " + dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select max(ExpAmount) from ExpeditureTbl", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            HighExpLbl.Text = "Rs: " + dt2.Rows[0][0].ToString();
        }
  ```

  Note: add these functions to initializer method.

  ![dashboar-redesign](./img/readme/dashboard.png)

  ## ⑩ Splash and Login development 🔒

  In Splash component:
    1. Check (names) for progressBar and splash screen
    2. Open ToolBox and add a "timer" component, and do double click to auto-generate its function.
    3. When timer1 arrives to 100, then, go to login screen. (also auto-generate Splash_Load() function to start the timer)

  In Login component:
    1. Check (names) for Role, UserName and Password. (also look for "Password Char" property)
    2. You have to open de Employee table definition and add a new field for password (EmpPass, varchar50, allow nulls)
    3. In Employees.cs (module), add new EmpPass field to anywhere that need it. (check git commit to view changes)
    4. Create the following function to Login button:

  ```csharp
        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter user name and password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UnameTb.Text == "Admin" && PasswordTb.Text == "Admin")
                        {
                            Employees prod = new Employees();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are the Admin, enter the correct Id ad Password");
                        }
                    }
                    else
                    {
                        Con.Open();

                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows cow = new Cows();
                            cow.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong userName or password");
                        }

                        Con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select a Role");
                }
            }
        }
  ```

  To test it, first, enter like Admin, and create a new employee,
  exit, and now login as the new employee you created before.
  It should work !!

