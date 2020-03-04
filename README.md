# HttpServerMock

HTTP Server for tests. It responds 200 - OK to every request.

## Getting Started

1. Clone repository: ```git clone https://github.com/OverlordEx3/HttpServerMock.git```
2. Open HttpServerMock.sln in Visual Studio 2019.

### Prerequisites

Before you can open the listener, you need to grant permission to the prefix URL. To do that, use
```
netsh http add urlacl url=http://+:555/ user=Domain/user
```
If you are on a non-English OS and you wish to use user 'Everyone', you need to use the translated word. (Ex. 'Todos' in spanish). (see this [post](https://stackoverflow.com/questions/4019466/httplistener-access-denied) in StackOverflow for more info.)


## Authors

* **Exequiel Beker** - *Initial work* - [OverlordEx3](https://github.com/OverlordEx3)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
