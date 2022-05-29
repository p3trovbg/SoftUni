function extensibleObject() {
    const proto = Object.getPrototypeOf(this);

    this.extend = function(template) {
        for (const key in template) {          
            if(typeof template[key] === 'function') {
                proto[key] = template[key];         
            } else {
                this[key] = template[key];
            }
        }

    }
    return this;
}

    const myObj = extensibleObject(); 
     
    const template = { 
      extensionMethod: function () {}, 
      extensionProperty: 'someString' 
    } 
    myObj.extend(template); 
    