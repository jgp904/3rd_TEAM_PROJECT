using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Repositorys;

namespace _3rd_TEAM_PROJECT_Desk
{
    internal static class Program
    {
        public static AcountDbContext acountdb;
        public static MProcessDbcontext mprocessdb;
        public static IWarehouseRepository inboundRepository;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using AcountDbContext acountDbContext = new AcountDbContext();
            using MProcessDbcontext mprocessDbContext = new MProcessDbcontext();
            
            // ������ �������� �̿��Ͽ� InboundRepository�� �ʿ��� DbContext ����
            IWarehouseRepository inboundRepository = new WarehouseRepository(acountDbContext, mprocessDbContext);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Main());
            //Application.Run(new Login());
        }
    }
}