using GOL_DALLESQL.BLL;

namespace GOL_DALLESQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Windows.Forms;

    [Table("GameArray")]
    public partial class GameArray
    {
        public int GameArrayID { get; set; }

        [MaxLength(100)]
        public string Seed { get; set; }

        [MaxLength(100)]
        public string NextTurn { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }



        //TODO:

        //C
        public void AddToDB(GameArray o)
        {
            using (Context context = new Context())
            {
                var objecttoAdd = o as GameArray;
                context.GameArrays.Add(o);
                context.SaveChanges();
            }

        }

    //R




        //U
        public void UpdateDb(GameArray o)
        {
            using (Context context = new Context())
            {







            }


        }

        //D 
        public void DeleteFromDb(GameArray o)
        {
                using (Context context = new Context())
                    {
                        var objecttoRemove = context.GameArrays.Find(o);
                        context.GameArrays.Remove(objecttoRemove);
                        context.SaveChanges();
                    }
                
         
        }

        //To Array

        

    public static object[,] ToArray(DataTable data)
    {
    var ret = Array.CreateInstance(typeof(object), data.Rows.Count, data.Columns.Count) as object[,];
        for (var i = 0; i < data.Rows.Count - 1; i++)
    for (var j = 0; j < data.Columns.Count - 1; j++)
    ret[i, j] = data.Rows[i][j];
    return ret;
    }


        //SEED

        public class GameArrayDBInitializer : CreateDatabaseIfNotExists<GOL_DALLESQL.Context>
        {
            HelperClass help = new HelperClass();


            protected override void Seed(Context context) => context.GameArrays.AddOrUpdate(x => x.GameArrayID,
                new GameArray() {Name = "Game 1", Seed =help.RandomSeed() }
        
            );
        }

    }
}
