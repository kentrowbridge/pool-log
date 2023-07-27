namespace PoolLog.Models
{
    /// <summary>
    ///     Model for a pool entity.
    /// </summary>
    public class Pool
    {
        /// <summary>
        ///     The pool ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the pool.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
