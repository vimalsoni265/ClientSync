namespace ClientSync.Core.Interface
{
    /// <summary>
    /// Interface for password helper
    /// </summary>
    public interface IPasswordHelper
    {
        /// <summary>
        /// Hashes the password using the salt.
        /// </summary>
        /// <returns>Salt</returns>
        string GenerateSalt();

        /// <summary>
        /// Hashes the password using the salt.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>Sha1Hash</returns>
        string ComputeHash(string password, string salt);

    }
}
