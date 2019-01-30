using System.Collections.Generic;

interface Messageable<T>
{
    List<T> SendMessage(List<T> phoneNumbers, T message);

    bool SendMessage(T phoneNumber, T message);
}