using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace NewEntry {
    public class Register {//Should be a partial class to integrate with the main program
        public class User {
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
            public string RepeatPassword { get; set; } = "";
        }
        //MongoConnection connection = new MongoConnection();
       //MongoClient client = new MongoClient(connection.connectionString);
       //MongodbDatabase database = client.GetDatabase(connection.databaseName);
       // MongoCollection<User> collection = database.GetCollection<User>("users");
        protected void Register_Click(object sender, EventArgs e) {//Landing Page should be like Name, Email, Password, RepeatPassword, Register Button
        //Existing users should be able to login with their Email and Password via a small link on bottom of landing page which will redirect to the login page
            /*var Connection = new MongoClient("mongodb://localhost");
            var client = new MongoClient(connection);
            var db = client.GetDatabase("Registration");
            var collection = db.GetCollection<User>("User");*/
            var user = new User {
                Name = "",//Name.Text.ToString(), Amisha's work
                Email = "",//Email.Text.ToString(),
                Password = "",//Password.Text.ToString(),
                RepeatPassword = "",//RepeatPassword.Text.ToString()
            };
            /*connection.Open();
            collection.InsertOne(user);*/
            Console.WriteLine("User Registered");
        }
        protected void ExistingUser_Click(object sender, EventArgs e) {
            //new Login().Show();//Login Page
            //this.Hide();
        }
        protected void Login_Click(object sender, EventArgs e) {
            /*var Connection = new MongoClient("mongodb://localhost");
            var client = new MongoClient(connection);
            var db = client.GetDatabase("Registration");
            var collection = db.GetCollection<User>("User");*/
            //connection.Open();
            /*string Login = "Select * from User where Email = '" + Email.Text.ToString() + "' and Password = '" + Password.Text.ToString() + "'";
            if (Login == "Select * from User where Email = '" + Email.Text.ToString() + "' and Password = '" + Password.Text.ToString() + "'") {
                Console.WriteLine("User Logged In");
                //Redirect to actual page
            }
            else {
                Console.Error.WriteLine("User Not Found");
            }
            */
        }
        protected void ShowPassword_CheckedChanged(object sender, EventArgs e) {
            /*if (ShowPassword.Checked) {
                Password.UseSystemPasswordChar = false;
            }
            else {
                Password.UseSystemPasswordChar = true;
            }*/
        }
        public static void Main() {
            int x = 0;
            Console.WriteLine(x);
        }
        public Register(int x) {
            x=0;
            Console.WriteLine(x);
        }
    }
}