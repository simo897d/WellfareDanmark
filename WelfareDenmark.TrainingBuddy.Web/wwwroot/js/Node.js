socket.on('message', function (message) {
    log('Got message: ', message);
    socket.broadcast.emit('message', message);
});

if (numClients === 0) {
    socket.join(room);
    socket.emit('created', room, socket.id);
} else if (numClients === 1) {
    socket.join(room);
    socket.emit('joined', room, socket.id);
    io.sockets.in(room).emit('ready');
} else { // max two clients
    socket.emit('full', room);
}