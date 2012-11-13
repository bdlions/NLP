<#macro functionController functionName>
	<#if functionName = "userAge">
		<@userAge/>
	</#if>
	<#if functionName = "age">
		<@age/>
	</#if>
	<#if functionName = "born">
		<@advancedAge/>
	</#if>
</#macro>

<#macro age>
	int age(in){
		return in;
	}
</#macro>

<#macro userAge>
	int userAge(int in, float x){
		return in * 2/x;
	}
</#macro>

<#macro advancedAge>
	int advancedAge(tcountry, tcolor, dateborn){
		If (dateborn>10) {
		return 10;       
		} 
		else {
		return dateborn; 
		}
	}
</#macro>
