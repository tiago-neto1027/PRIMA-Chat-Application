using PRIMA.Interfaces;

namespace PRIMA.Services
{
    /// <summary>
    /// Service for handling client operations.
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="clientInstance">An instance of the <see cref="IClient"/> interface.</param>

        public ClientService(IClient clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Closes the client connection.
        /// </summary>
        public void CloseClient()
        {
            client.Close();
        }
    }
}
