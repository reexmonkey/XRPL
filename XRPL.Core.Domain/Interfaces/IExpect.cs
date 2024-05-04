namespace XRPL.Core.Domain.Interfaces
{
    /// <summary>
    /// Specifies an interface where the implementing type expects the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to relate to.</typeparam>
    public interface IExpect<out T> where T : class
    {
    }
}