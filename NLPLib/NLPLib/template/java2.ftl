package ${class.packageName};
class ${class.name}{
<#list aKeys as attrName>
    private ${attrName["accessModifier"]} ${attrName["name"]};
</#list>

<#list aKeys as attrName>
	public ${attrName["accessModifier"]} get${attrName["name"]?cap_first}(){
        return this.${attrName["name"]};
    }
    public void set${attrName["name"]?cap_first}(${attrName["accessModifier"]} ${attrName["name"]}){
        this.${attrName["name"]} = ${attrName["name"]};
    }
</#list>
    public static void main(String args[]){
    	if(${ifBlock.left1} ${ifBlock.expression1} ${ifBlock.right1} ){
    		set${ifBlock.actionLeft?cap_first}(${ifBlock.actionRight}); 
    	}
    	
    }
}