using ConsoleApp2.Controller;
using ConsoleApp2.Model;

MainController mainController = new MainController();
DBInit dataBaseInit = new DBInit();
dataBaseInit.InitializeDataBase();
mainController.WritePallets();
mainController.WriteBoxes();