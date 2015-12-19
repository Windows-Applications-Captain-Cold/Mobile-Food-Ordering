var mongoose = require('mongoose'),
    bcrypt = require('bcrypt-nodejs');

var userSchema = mongoose.Schema({
    Email: String,
    Password: String,
    Name: String,
    Organisation: String,
    Projects: [],
    Team: String,
    SystemMessages: Array,
    PersonalMessages: Array
});

userSchema.methods.generateHash = function (password) {
    return bcrypt.hashSync(password, bcrypt.genSaltSync(8), null);
}

userSchema.methods.validatePassword = function (password) {
    return password == this.Password;
    //console.log("USER SERVER PASSWORD: " + this.Password);
    //return bcrypt.compareSync(password, this.Password);
}

module.exports = mongoose.model('User', userSchema);
