function getIconUrl(email) {
    var hash = md5(email);
    var url = "https://www.gravatar.com/avatar/" + hash + "?s=200";
    return url;
};