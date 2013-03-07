Test this using some type of REST Client

Can POST phones:

NOTE: Need to set the Content-Type and Accept headers to be application/json

Add Phone Example:
POST body contents 
{"Number": "360-123-4567"}

Add Message Example:
POST body contents
{
	"Content": "Message Contents",
	"Source": "360-123-4567",
	"Target": "360-123-8901"
}