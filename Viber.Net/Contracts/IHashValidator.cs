namespace Viber.Net.Contracts
{
    /// <summary>
    /// Contract definition of Hash Validator
    /// </summary>
    public interface IHashValidator
    {
        /// <summary>
        /// validates signature with produces hash value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="signature"></param>
        /// <returns>true if valid, false otherwise</returns>
        bool IsValid(string signature, byte[] value);
    }
}
