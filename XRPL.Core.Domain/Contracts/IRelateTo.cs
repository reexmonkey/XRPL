namespace XRPL.Core.Domain.Contracts
{
    /// <summary>
    /// Specifies an interface that relates the implementing type with the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to relate to.</typeparam>
    public interface IRelateTo<out T> where T : class
    {
    }
}