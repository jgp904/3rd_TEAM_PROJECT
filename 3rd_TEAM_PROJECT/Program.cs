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

			factoryRepository = new FactoryRepository();//����
            equipmentRepository = new EquipmentRepository();//����
            processRepository = new ProcessRepository();//����
            itemRepository = new ItemRepository(); //ǰ��


			// ������ �������� �̿��Ͽ� InboundRepository�� �ʿ��� DbContext ����
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