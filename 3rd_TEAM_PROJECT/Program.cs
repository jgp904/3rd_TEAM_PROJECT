using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.InterFace;
using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;

namespace _3rd_TEAM_PROJECT_Desk
{
    internal static class Program
    {
        public static AccountDbContext accountdb; // Account Context 생성
        public static MProcessDbcontext mprocessdb; //Process Context 생성
        //----------------WareHouse------------------------//
        public static IWarehouseRepository warehouseRepository;
        public static IInboundRepository? inboundRepository;
        public static IOutboundRepository outboundRepository;

        //-----------------Process-------------------------//
        public static IFactoryRepository? factoryRepository;
        public static IEquipmentRepository equipmentRepository;
        public static IProcessRepository processRepository;
        public static IItemRepository itemRepository;
        public static ILotRepository lotRepository;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using AccountDbContext accountDbContext = new AccountDbContext();
            using MProcessDbcontext mprocessDbContext = new MProcessDbcontext();
            accountdb = accountDbContext;
            mprocessdb = mprocessDbContext;

            //-------------------------Mrocess-------------------------------//
            factoryRepository = new FactoryRepository(); //공장
            equipmentRepository = new EquipmentRepository(); //설비
            processRepository = new ProcessRepository(); //공정
            itemRepository = new ItemRepository(); //품번
            lotRepository = new LotRepository(); //Lot번호

            //-------------------------WareHouse-----------------------------//
            warehouseRepository = new WarehouseRepository(accountDbContext, mprocessDbContext);
            inboundRepository = new InboundRepository(accountDbContext, mprocessDbContext); 
            outboundRepository = new OutboundRepository(accountDbContext, mprocessDbContext); 

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
            //Application.Run(new Main());
            //Application.Run(new ProcessForm());
        }
    }
}