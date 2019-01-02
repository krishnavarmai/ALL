$(function () {
    var originTwo = "<%=this.ConfiguratorAuthURL%>";
    var windowTwo = null;
    window.addEventListener("message", handleMessage, false);
    //window.onerror = windowErrorHandler;
    //log('this is Sitefinity...');
    //log('host: ' + location.host);
    function handleMessage(event) {
        debugger;
        //if (event.origin == originTwo) {
        if (!windowTwo) windowTwo = event.source;
        var d = JSON.parse(event.data);
        if (!d) return false;
        for (var i = 0; i < d.length; i++) {
            var url = "/addproductnametocart/catalog/" + d[i].ItemId + "/1/" + d[i].Quantity;
            AjaxCart.addProductNameToCart_Catalog(url);
        }
        //ECOMM.addItemsToCart(d);
        //window.location.href = '/my-cart';
        //} else {
        //    dispError('message from untrusted origin: ' + event.origin);
        //}
    }
    // use JSON to send structured data
    function sendObject(o) {
        if (!windowTwo) { return false; }
        var s = JSON.stringify(o);
        windowTwo.postMessage(s, originTwo);
        return true;
    }
    // shortcut for getElementById
    function element(id) { return document.getElementById(id); }
    function clearDisp() {
        element('pageResults').innerHTML = '';
        element('message').innerHTML = '';
        element('message').className = '';
    }
    function dispMessage(message) {
        m = element('message');
        m.className = 'message';
        if (m.textContent.length > 0) {
            m.innerHTML += '<br />' + message;
        } else m.innerHTML = message;
    }
    function windowErrorHandler(message, filename, lineno) {
        if (message.indexOf('elem is not defined') > 0) return true; // firefox bug
        dispError(message + ' (' + filename + ':' + lineno + ')');
        return true;
    };
    function dispError(errorMessage) {
        element('pageResults').innerHTML +=
            errorMessage ? '<p class="error">' + errorMessage + '</p>\n' : '';
    }
    function log(m) {
        if (!m || m.length < 1) return;
        logElement = element('log');
        if (logElement.textContent.length > 0) logElement.innerHTML += '<br />';
        logElement.innerHTML += nowTimeString() + ' ' + m;
    }
    function nowTimeString() {
        var d = new Date();
        return numToString(d.getUTCHours(), 2) + ':' + numToString(d.getUTCMinutes(), 2) + ':' +
            numToString(d.getUTCSeconds(), 2) + '.' + numToString(d.getUTCMilliseconds(), 3);
    }
    function numToString(num, len) {
        num = num + '';
        while (num.length < len) num = '0' + num;
        return num;
    }
});