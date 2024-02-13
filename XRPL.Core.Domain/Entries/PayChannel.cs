using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a payment channel.
    /// </summary>
    public class PayChannel: LedgerEntryBase
    {
        /// <summary>
        /// The source address that owns this payment channel. 
        /// <para/>This comes from the sending address of the transaction that created the channel.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// Total XRP, in drops, that has been allocated to this channel. 
        /// <para/>This includes XRP that has been paid to the destination address. 
        /// This is initially set by the transaction that created the channel and can be increased 
        /// if the source address sends a PaymentChannelFund transaction.
        /// </summary>
        public string? Amount { get; set;}

        /// <summary>
        /// Total XRP, in drops, already paid out by the channel. 
        /// <para/>The difference between this value and the Amount field is how much XRP can still be paid to the destination address with PaymentChannelClaim transactions. 
        /// If the channel closes, the remaining difference is returned to the source address.
        /// </summary>
        public string? Balance { get; set; }

        /// <summary>
        /// The immutable expiration time for this payment channel, in seconds since the Ripple Epoch. 
        /// <para/>This channel is expired if this value is present and smaller than the previous ledger's close_time field. 
        /// This is optionally set by the transaction that created the channel, and cannot be changed.
        /// </summary>
        public uint CancelAfter { get; set; }

        /// <summary>
        /// The destination address for this payment channel. 
        /// <para/>While the payment channel is open, this address is the only one that can receive XRP from the channel. 
        /// This comes from the Destination field of the transaction that created the channel.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the destination for this payment channel, such as a hosted recipient at the destination address.
        /// </summary>
        public string? DestinationTag { get; set; }

        /// <summary>
        /// A hint indicating which page of the destination's owner directory links to this entry, 
        /// in case the directory consists of multiple pages. Omitted on payment channels created before enabling the fixPayChanRecipientOwnerDir amendment.
        /// </summary>
        public string? DestinationNode { get; set;}

        /// <summary>
        /// The mutable expiration time for this payment channel, in seconds since the Ripple Epoch. 
        /// <para/>The channel is expired if this value is present and smaller than the previous ledger's close_time field. 
        /// See Channel Expiration for more details.
        /// </summary>
        public uint Expiration { get; set; }

        /// <summary>
        /// A hint indicating which page of the source address's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public string? PreviousTxnID { get; set;}

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this entry.
        /// </summary>
        public uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// Public key, in hexadecimal, of the key pair that can be used to sign claims against this channel. 
        /// <para/>This can be any valid secp256k1 or Ed25519 public key. 
        /// This is set by the transaction that created the channel and must match the public key used in claims against the channel. 
        /// The channel source address can also send XRP from this channel to the destination without signed claims.
        /// </summary>
        public string? PublicKey { get; set; }


        /// <summary>
        /// Number of seconds the source address must wait to close the channel if it still has any XRP in it. 
        /// <para/>Smaller values mean that the destination address has less time to redeem any outstanding claims after the source address requests to close the channel. 
        /// Can be any value that fits in a 32-bit unsigned integer (0 to 2^32-1). 
        /// This is set by the transaction that creates the channel.
        /// </summary>
        public uint SettleDelay { get; set; }

        /// <summary>
        /// An arbitrary tag to further specify the source for this payment channel, such as a hosted recipient at the owner's address.
        /// </summary>
        public uint SourceTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayChannel"/> class.
        /// </summary>
        public PayChannel()
        {
            LedgerEntryType = "PayChannel";
        }
    }
}
