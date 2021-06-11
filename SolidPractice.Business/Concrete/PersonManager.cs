using SolidPractice.Business.Abstract;

namespace SolidPractice.Business.Concrete
{

    //TÜM PERSON SERVİSLERİNDE ORTAK OLAN İŞLEMLER
    public abstract class PersonManager : IPersonService
    {

        public string JointPersonOperation1()
        {
            return "Ortak Operasyon (1) Tamamlandı.";
        }

        public string JointPersonOperation2()
        {
            return "Ortak Operasyon (2) Tamamlandı.";
        }

        public string JointPersonOperation3()
        {
            return "Ortak Operasyon (3) Tamamlandı.";
        }
    }
}