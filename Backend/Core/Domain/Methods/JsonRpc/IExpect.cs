namespace XRPL.Core.Domain.Methods.JsonRpc
{
    /// <summary>
    /// Specifies an interface where the implementing type expects <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to expect.</typeparam>
    public interface IExpect<out T> where T : class
    {
    }
}
