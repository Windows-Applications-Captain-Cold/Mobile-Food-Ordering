var mongoose = require('mongoose');

var foodSchema = mongoose.Schema({
    Name : String,
    Type: String,
    Price: Number,
    Description: String,
    ImgSource: String
});

module.exports = mongoose.model('Food', foodSchema);
