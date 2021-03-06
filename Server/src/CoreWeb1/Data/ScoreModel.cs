using System.ComponentModel.DataAnnotations;

namespace CoreWeb1.Data
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
    /// <remarks>
    /// Because Unity json serializer does not know how to deserialize arrays.
    /// </remarks>
    public class ScoreModelContainer
    {
        public ScoreModel[] Scores { get; set; }
    }
}
