using _18_SaveData.Data;
using _18_SaveData.Entities;
using _18_SaveData.Topics;
using _18_SaveData.Utils;

namespace _18_SaveData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                #region Basic Save
                BasicSave.RunBasicSave(context);
                BasicSave.RunBasicUpdate(context);
                BasicSave.RunBasicDelete(context);
                BasicSave.RunMultipleOperationsWithSingleSave(context);
                BasicSave.RunAddRelatedEntities(context);
                #endregion


            }
        }

        
    }
}
