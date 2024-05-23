using System.Runtime.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to a deposit authorized request.
    /// </summary>
    internal class DepositAuthorizedResponse : ResponseBase<DepositAuthorizedResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="DepositAuthorizedResponse"/> object.
    /// </summary>
    [DataContract]
    public abstract class DepositAuthorizedResult : ResultBase
    {
        /// <summary>
        /// Whether the specified source account is authorized to send payments directly to the destination account.
        /// If true, either the destination account does not require Deposit Authorization or the source account is preauthorized.
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>

    }
}
