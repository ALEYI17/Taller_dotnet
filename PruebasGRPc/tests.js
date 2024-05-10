import grpc from 'k6/net/grpc';
import { check, sleep } from 'k6';

const client = new grpc.Client();
client.load([], 'user.proto');

export default () => {
    client.connect('localhost:5243', {
        plaintext: true,
    });

    const data = { id: 1 };
    const response = client.invoke('Datos.DataBuff/ReadUsuario', data);

    check(response, {
        'status is OK': (r) => r && r.status === grpc.StatusOK,
    });

    console.log(JSON.stringify(response.message));

    client.close();
    sleep(1);
};
