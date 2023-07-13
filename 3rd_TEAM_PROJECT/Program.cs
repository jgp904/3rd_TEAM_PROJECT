using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Repositorys;

namespace _3rd_TEAM_PROJECT_Desk
{
    internal static class Program
    {
        public static AcountDbContext acountdb;
        public static MProcessDbcontext mprocessdb;
        public static IInboundRepository inboundRepository;
        public static IFactoryRepository factoryRepository;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using AcountDbContext acountDbContext = new();
            using MProcessDbcontext mprocessDbContext = new();
            acountdb = acountDbContext;
            mprocessdb = mprocessDbContext;

            factoryRepository = new FactoryRepository();//공장
      

        
            // 생성자 인젝션을 이용하여 InboundRepository에 필요한 DbContext 전달
            IInboundRepository inboundRepository = new InboundRepository(acountDbContext, mprocessDbContext);
            


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