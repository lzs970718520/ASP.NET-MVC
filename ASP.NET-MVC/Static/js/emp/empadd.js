$(function(){
	//init();
	//数据验证
	//checkItem();
	//提交表单位
	commitItem();
});
/****************获得焦点同时得到两个下拉框的内容********************/
function init() {
	$("#erealname").focus();
	//得到下拉框的值 
	$.ajax({
		url:'emp_allx.action',
		dataType:'json',
		type:'post',
		data:'',
		async : true,
		success:function(mydata)
		{
		   $.each(mydata,function(index,xx){
			   $("#pid").append("<option value="+xx.pid+">"+xx.pname+"</option>");
		   });
		}
	});
	
	$.ajax({
		url:'emp_ally.action',
		dataType:'json',
		type:'post',
		data:'',
		async : true,
		success:function(mydata)
		{

		   $.each(mydata,function(index,xx){
			   $("#jid").append("<option value="+xx.jid+">"+xx.jname+"</option>");
		   });
		}
	});
};
/******************失去焦点事件****************************/
function checkItem()
{
	$("#pname").focusout(function(){
		var pname=$("#pname").val();
		if(pname.length==0)
			{
			   layer.tips('部门名称不能为空！','#pname',{tips:[2,'red']});
			}
		else
			{
			   $.ajax({
				   url:'part_getAllName.action',
				   dataType:'json',
				   type:'post',
				   data:{pname:pname},
				   async : true,
				   success:function(mydata)
				   {
					   if(mydata==0)
						   {
						      $("#pname").addClass("newsuccess");
					          $("#pname").removeClass("newerror");
						   }
					   else
						   {
						       layer.tips('对不起部门已存在！','#pname',{tips:[2,'red']});
						   }
					   $("#botao").val(mydata);
				   }
			   });
			}
	});
}
/******************************提交表单********************************/
function commitItem()
{
	$(".btn").bind("click",function(){
	var erealname = $("#erealname").val();
	var ename = $("#ename").val();
	if(erealname.length==0)
		{
		   layer.tips('员工真实姓名不能为空！','#erealname',{tips:[2,'red']});
		   $("#erealname").focus();
		   return false;
		}
	else if(ename.length==0)
		{
		   layer.tips('员工账号不能为空！','#ename',{tips:[2,'red']});
		   $("#ename").focus();
		   return false;
		}
	});
}