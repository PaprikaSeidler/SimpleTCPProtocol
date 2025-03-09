from socket import *
serverName = 'localhost'
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

method = input("Choose method (Random, Add, Subtract): ")
clientSocket.send(f"{method}\n".encode())

response = clientSocket.recv(1024).decode()
print(response)

if response.__contains__("Input numbers"):
    numbers = input()
    clientSocket.send(f"{numbers}\n".encode())

result = clientSocket.recv(1024).decode()
print(result)

clientSocket.close()