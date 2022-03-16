﻿using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        LogService logService = new LogService();
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
            dashboardToolStripMenuItem.ForeColor = Color.White;
            dashboardToolStripMenuItem.BackColor = Color.Black; 
        }
        private void ColorListView(ListView listview)
        {
            for (int i = 0; i < listview.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listview.Items[i].BackColor = Color.LightBlue;
                }
            }
        }
        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                pnlRoomPanel.Hide();
                pnlTeacherPanel.Hide();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }

            else if (panelName == "Students")
            {
                ShowCorrectPannel(pnlStudents);
                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService();
                    List<Student> studentList = studService.GetStudents();

                    // clear the listview before filling it again
                    listViewStudents.Clear();


                    listViewStudents.View = View.Details;
                    listViewStudents.Columns.Add("Student id", 80);
                    listViewStudents.Columns.Add("First name", 150);
                    listViewStudents.Columns.Add("Last name", 150);
                    listViewStudents.Columns.Add("Date of birth", 100);
                    listViewStudents.Columns.Add("Room number", 80);

                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.StudentId.ToString());
                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(s.DateOfBirth.ToString("yyyy/MM/dd"));
                        li.SubItems.Add(s.RoomNumber.ToString());
                        listViewStudents.Items.Add(li);
                    }

                    ColorListView(listViewStudents);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                    logService.WriteLog(e.Message);
                }
            }
            else if (panelName == "Teachers")
            {
                ShowCorrectPannel(pnlTeacherPanel);


                listViewTeachers.Clear();

                TeacherService teacherService = new TeacherService();
                List<Teacher> teacherList = teacherService.GetTeachers();

                listViewTeachers.View = View.Details;

                listViewTeachers.Columns.Add("Teacher id", 80);
                listViewTeachers.Columns.Add("First name", 120);
                listViewTeachers.Columns.Add("Last name", 120);
                listViewTeachers.Columns.Add("Room number", 80);
                listViewTeachers.Columns.Add("Supervisor", 80);
                foreach (Teacher teacher in teacherList)
                {
                    ListViewItem li = new ListViewItem(teacher.TeacherID.ToString());
                    li.SubItems.Add(teacher.FirstName);
                    li.SubItems.Add(teacher.LastName);
                    li.SubItems.Add(teacher.RoomNumber.ToString());
                    li.SubItems.Add(teacher.Supervisor.ToString());
                    listViewTeachers.Items.Add(li);
                }
                ColorListView(listViewTeachers);
            }
            else if (panelName == "Revenue report")
            {
                ShowCorrectPannel(pnlRevenueReportPanel);
                try
                {
                    //                    Sales(total number of drinks sold), Turnover(total[sales * sales price of those drinks]), Number of customers
                    //                    (students who purchased at least one drink).The report is refreshed for the period selected by the user
                    //                    by way of a calendar interface with a start and end date.The application gives the user feedback if they have chosen
                    //                    an invalid date and/or period.The dates used are displayed in order of size (dd-mm-yyyy).

                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                    logService.WriteLog(e.Message);
                }
            }
            else if (panelName == "Cash register")
            {
                ShowCorrectPannel(pnlCashRegisterPanel);
                try
                {
                    StudentService studService = new StudentService();
                    List<Student> studentList = studService.GetStudents();


                    studentsListView.View = View.Details;
                    studentsListView.Columns.Add("Student id", 50);
                    studentsListView.Columns.Add("First name", 120);
                    studentsListView.Columns.Add("Last name", 120);
                    studentsListView.Columns.Add("Date of birth", 70);
                    studentsListView.Columns.Add("Room number", 50);


                    foreach (Student s in studentList)
                    {
                        s.StudentId.ToString();

                        ListViewItem li = new ListViewItem(s.StudentId.ToString());
                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(s.DateOfBirth.ToString("yyyy/MM/dd"));
                        li.SubItems.Add(s.RoomNumber.ToString());
                        studentsListView.Items.Add(li);

                    }



                    DrinkService driService = new DrinkService();
                    List<Drinks> drinkList = driService.GetDrinks();


                    drinksListView.View = View.Details;
                    drinksListView.Columns.Add("Order id", 50);
                    drinksListView.Columns.Add("Product id", 50);
                    drinksListView.Columns.Add("Student id", 50);
                    drinksListView.Columns.Add("Date of purchase", 70);


                    foreach (Drinks d in drinkList)
                    {
                        d.OrderId.ToString();

                        ListViewItem li = new ListViewItem(d.OrderId.ToString());
                        li.SubItems.Add(d.ProductId.ToString());
                        li.SubItems.Add(d.StudentId.ToString());
                        li.SubItems.Add(d.DateOfPurchase.ToString());
                        drinksListView.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                    logService.WriteLog(e.Message);
                }
            }
            try
            {
                //(VOID aanmaken voor hide panels?)
                if (panelName == "Rooms")
                {
                    ShowCorrectPannel(pnlRoomPanel);

                    try
                    {
                        //AANPASSEN EN METHODES AANMAKEN. 
                        // fill the rooms listview within the rooms panel with a list of rooms
                        RoomService roomService = new RoomService();
                        List<Room> roomList = roomService.GetRooms();

                        // clear the listview before filling it again
                        listViewRoom.Clear();

                        listViewRoom.View = View.Details;
                        listViewRoom.Columns.Add("Number", 80);
                        listViewRoom.Columns.Add("Capacity", 80);
                        listViewRoom.Columns.Add("Type", 120);
                    
                        foreach (Room room in roomList)
                        {
                            ListViewItem li = new ListViewItem(room.Number.ToString());
                            li.SubItems.Add(room.Capacity.ToString());
                            li.SubItems.Add(room.Type);
                            listViewRoom.Items.Add(li);                            
                        }
                        ColorListView(listViewRoom);

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Listview could not be loaded properly.");
                        logService.WriteLog(e.Message);
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Panel could not be loaded properly." + e.Message);
            }            
        }
        private void ShowCorrectPannel(Panel panel)
        {
            foreach(Control c in Controls)
            {
                if (c != panel && c != menuStrip1)
                {
                    c.Hide();
                }
                else
                {
                    c.Show();
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ChangeToolStripMenu(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripMenuItem tsmi in menuStrip1.Items)
            {
                tsmi.ForeColor = default(Color);
                tsmi.BackColor = default(Color);
                for(int i = 0; i < tsmi.DropDownItems.Count; i++)
                {
                    tsmi.DropDownItems[i].ForeColor = default(Color);
                    tsmi.DropDownItems[i].BackColor = default(Color);
                }
            }
            menuItem.ForeColor = Color.White;
            menuItem.BackColor = Color.Black;
            if (menuItem.OwnerItem != null)
                menuItem.OwnerItem.BackColor = Color.LightGray ;
        }
        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
            ChangeToolStripMenu(dashboardToolStripMenuItem);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
            ChangeToolStripMenu(studentsToolStripMenuItem);
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // within this method I want to show what happens when 'Rooms' is clicked
            showPanel("Rooms");
            ChangeToolStripMenu(roomsToolStripMenuItem);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.Red;
        }
        private void pnlTeacher_Paint(object sender, PaintEventArgs e)
        {
            showPanel("Rooms");
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
            ChangeToolStripMenu(teachersToolStripMenuItem);
        }
        private void activitiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Activities");
            ChangeToolStripMenu(activitiesToolStripMenuItem);
        }
        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Revenue report");
            ChangeToolStripMenu(revenueReportToolStripMenuItem);
        }

        private void pictureBoxSomerenTeacher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Een leuke tekst als je op de foto drukt");
        }

        private void pictureBoxSomerenRoom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Een leuke tekst als je op de foto drukt");
        }

        private void pictureBoxSomerenStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Een leuke tekst als je op de foto drukt");
        }

        private void CashregistertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Cash register");
            ChangeToolStripMenu(CashregistertoolStripMenuItem);
        }

        private void checkOutbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your transaction has been completed! ");
        }
    }
}
