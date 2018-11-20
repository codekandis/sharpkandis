using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace SharpKandis
{
	/// <summary>
	/// Represents an extension class of all `System.Uri` classes.
	/// </summary>
	public static class UriXt
	{
		/// <summary>
		/// Determines the list of end points of a specified URI.
		/// </summary>
		/// <param name="reference">The URI to determine its list of end points.</param>
		/// <param name="addressFamily">The address family the URI passed in the argument `uri` is depending on.</param>
		/// <returns>The list of end points of the URI passed in the argument `uri`.</returns>
		public static IEnumerable<EndPoint> EndPointsGet( this Uri reference, AddressFamily addressFamily )
		{
			IPHostEntry ipHostEntry = Dns.GetHostEntry( reference.Host );
			IEnumerable<EndPoint> endPoints =
				from
					IPAddress ipAddressFetched
				in
					ipHostEntry.AddressList
				where
					ipAddressFetched.AddressFamily == addressFamily
				select
					new IPEndPoint( ipAddressFetched, reference.Port );
			return endPoints;
		}

		/// <summary>
		/// Determines and specified end point of a list of end points of a specified URI.
		/// </summary>
		/// <param name="reference">The URI to determine its specified end point.</param>
		/// <param name="addressFamily">The address family the URI passed in the argument `uri` is depending on.</param>
		/// <param name="index">The index of the end point to determine from the end point list of the specified URI passed in the argument `uri`.</param>
		/// <returns>The end point specified by its index passed in the argument `index` of the list of end points of the URI passed in the argument `uri`.</returns>
		public static EndPoint EndPointGet( this Uri reference, AddressFamily addressFamily, int index )
		{
			IEnumerable<EndPoint> endPoints = reference.EndPointsGet( addressFamily );
			return 0 == endPoints.Count( )
						? null
						: endPoints.ElementAt( index );
		}
	}
}
