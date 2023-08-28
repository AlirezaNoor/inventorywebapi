namespace INV.Services.Intertface
{
    public interface ITransaction
    {
        void Commit();
        void rollback();
        void Dispose();
    }
}
