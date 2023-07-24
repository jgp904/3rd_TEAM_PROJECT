using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;

namespace _3rd_TEAM_PROJECT_Desk
{
    internal static class Program
    {
        public static AcountDbContext acountdb;
        public static MProcessDbcontext mprocessdb;
        public static IFactoryRepository? factoryRepository;
        public static IWarehouseRepository warehouseRepository;
        public static IInboundRepository? inboundRepository;
        public static IOutboundRepository outboundRepository;
        public static IEquipmentRepository equipmentRepository;
        public static IProcessRepository processRepository;
        public static IItemRepository itemRepository;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using AcountDbContext acountDbContext = new AcountDbContext();
            using MProcessDbcontext mprocessDbContext = new MProcessDbcontext();
			acountdb = acountDbContext;
			mprocessdb = mprocessDbContext;

			factoryRepository = new FactoryRepository();//공장
            equipmentRepository = new EquipmentRepository();//설비
            processRepository = new ProcessRepository();//공정
            itemRepository = new ItemRepository(); //품번


			// 생성자 인젝션을 이용하여 InboundRepository에 필요한 DbContext 전달
			warehouseRepository = new WarehouseRepository(acountDbContext, mprocessDbContext);
            inboundRepository = new InboundRepository(acountDbContext, mprocessDbContext);
            outboundRepository = new OutboundRepository(acountDbContext, mprocessDbContext);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new Main());
            Application.Run(new ProcessForm());
        }
    }
}