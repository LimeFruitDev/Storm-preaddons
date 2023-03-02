using Sandbox;
using System.Collections.Generic;

namespace Storm;

public static class NetworkDisconnectionReasonExtensions
{
	private static readonly Dictionary<NetworkDisconnectionReason, string> NetworkDisconnectionReasons = new()
	{
		{NetworkDisconnectionReason.INVALID, "Invalid"},
		{NetworkDisconnectionReason.SHUTDOWN, "Shutdown"},
		{NetworkDisconnectionReason.DISCONNECT_BY_USER, "Disconnect by user"},
		{NetworkDisconnectionReason.DISCONNECT_BY_SERVER, "Disconnect by server"},
		{NetworkDisconnectionReason.LOST, "Connection lost"},
		{NetworkDisconnectionReason.STEAM_BANNED, "Steam banned"},
		{NetworkDisconnectionReason.STEAM_INUSE, "Steam account in use"},
		{NetworkDisconnectionReason.STEAM_TICKET, "Steam ticket revoked"},
		{NetworkDisconnectionReason.STEAM_LOGON, "Steam logon failed"},
		{NetworkDisconnectionReason.STEAM_AUTHCANCELLED, "Steam auth cancelled"},
		{NetworkDisconnectionReason.STEAM_AUTHALREADYUSED, "Steam auth ticket already in use"},
		{NetworkDisconnectionReason.STEAM_AUTHINVALID, "Steam auth is invalid"},
		{NetworkDisconnectionReason.STEAM_VACBANSTATE, "VAC banned"},
		{NetworkDisconnectionReason.STEAM_LOGGED_IN_ELSEWHERE, "Steam account is logged in elsewhere"},
		{NetworkDisconnectionReason.STEAM_DROPPED, "Connection dropped by Steam"},
		{NetworkDisconnectionReason.STEAM_OWNERSHIP, "Steam ownership revoked or invalid"},
		{NetworkDisconnectionReason.BADDELTATICK, "Bad delta-tick"},
		{NetworkDisconnectionReason.TIMEDOUT, "Connection timed out"},
		{NetworkDisconnectionReason.DISCONNECTED, "Disconnected"},
		{NetworkDisconnectionReason.Kicked, "Kicked"},
		{NetworkDisconnectionReason.Banned, "Banned"},
		{NetworkDisconnectionReason.Kickbanned, "Kick-banned"},
		{NetworkDisconnectionReason.USERCMD, "Invalid CUserCmd"},
		{NetworkDisconnectionReason.REJECTED_BY_GAME, "Rejected by game"},
		{NetworkDisconnectionReason.BAD_SERVER_PASSWORD, "Bad password"},
		{NetworkDisconnectionReason.CONNECTION_FAILURE, "Connection failure"},
		{NetworkDisconnectionReason.RECONNECTION, "Reconnecting"},
		{NetworkDisconnectionReason.CREATE_SERVER_FAILED, "Server creation failed"},
		{NetworkDisconnectionReason.EXITING, "Exiting"},
		{NetworkDisconnectionReason.CLIENT_CONSISTENCY_FAIL, "Client consistency fail"},
		{NetworkDisconnectionReason.CLIENT_UNABLE_TO_CRC_MAP, "Map CRC failed"},
		{NetworkDisconnectionReason.CLIENT_NO_MAP, "Missing map"},
		{NetworkDisconnectionReason.CLIENT_DIFFERENT_MAP, "Client's map version is different from the server's"},
		{NetworkDisconnectionReason.SERVER_REQUIRES_STEAM, "The server requires Steam to play"},
		{NetworkDisconnectionReason.STEAM_DENY_BAD_ANTI_CHEAT, "Denied by steam (BAD_ANTI_CHEAT)"},
		{NetworkDisconnectionReason.SERVER_SHUTDOWN, "Server shutdown"},
		{NetworkDisconnectionReason.CONNECT_REQUEST_TIMEDOUT, "Connection request timed-out"},
		{NetworkDisconnectionReason.SERVER_INCOMPATIBLE, "Server is incompatible with the client's game version"},
		{NetworkDisconnectionReason.INTERNAL_ERROR, "Internal error"},
		{NetworkDisconnectionReason.REJECT_BADCHALLENGE, "Bad challenge"},
		{NetworkDisconnectionReason.REJECT_BADPASSWORD, "Bad password"},
		{NetworkDisconnectionReason.REJECT_SERVERFULL, "Server is full"},
		{NetworkDisconnectionReason.REJECT_STEAM, "Rejected by Steam"},
		{NetworkDisconnectionReason.REJECT_BANNED, "Banned"}
	};

	public static string GetName( this NetworkDisconnectionReason self )
	{
		return NetworkDisconnectionReasons[self] ?? self.ToString();
	}
}
