using System.ComponentModel.DataAnnotations;

namespace CoreWeb1.Modules.Score
{
    /// <summary>
    /// This entity is persistent via the ScoreContext
    /// </summary>
    public class ScoreModel
    {
        //Key defines our primary lookup id

        /// <summary>
        /// UNIQUE Name, using an ID is a better practice
        /// </summary>
        [Key]
        public string UserName { get; set; }

        /// <summary>
        /// Uses score
        /// </summary>
        public int Points { get; set; }
    }

    /// <summary>
    /// Client side data model.
    /// This can be shared......
    /// </summary>
    public class ScoreModelContainer
    {
        public ScoreModel[] Scores { get; set; }
    }
}
