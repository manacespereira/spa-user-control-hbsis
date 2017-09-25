var express = require('express'),
    app = express(),
    routes = require('../app/routes');

app.use(express.static('./dist'));

routes(app);

module.exports = app;