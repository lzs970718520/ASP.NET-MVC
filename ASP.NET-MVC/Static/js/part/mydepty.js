var current = 1;
var up = 0;
var next = 0;
var allpages = 0;
var allcount = 0;
var editFlag = 0;//部门操作的表示1为添加部门 2为修改部门
var pflag = 0;
$(function () {
    //加载页面数据
    //initPart();
    ////点击首页
    //getFirst();
    //点击上一页
    //getUp();
    ////点击下一页
    //getNext();
    ////点击尾页
    //getLast();
    ////点击转到第几页
    //getZhan();
    //添加部门
    addPart();
    //弹出修改页面
    //outupdate();
    ////删除
    //mydel();
    ////查询已经撤销的部门
    //mydelAll();
    ////返回查询
    //getBack();
    ////恢复部门
    //getHuiFu();

});

/***********************************/
function initPart() {
    $(".tablelist,.tablelist th").css("text-align", "center");
    //getAlll(1, 0);
}

/********************这里为了静态页面，不刷新数据，故意破坏函数***************************/
function getAll(current, flag) { }
/********************这里刷新数据，有动态数据可以更改该函数名为getAll***************************/


function getAll1(state, current) {
    
    //pflag = flag;
    flag = 0;

    $(".tablelist").empty();

    if (flag == 0) {
        $(".tablelist").append("<thead><tr align='center'><th width='10%' align='center'>编号</th><th width='25%' align='center'>部门名称</th><th width='35%' align='center'>部门备注</th><th width='15%' align='center'>修改</th><th width='15%'>撤销部门</th></tr></thead>");
    }
    else {
        $(".tablelist").append("<thead><tr align='center'><th width='10%' align='center'>编号</th><th width='25%' align='center'>部门名称</th><th width='35%' align='center'>部门备注</th><th width='15%' align='center'>恢复部门</th></tr></thead>");
    }

    $.ajax({
        url: '/Department/ShowMsg',
        dataType: 'json',
        data: { current: current, pflag: flag },
        type: 'post',
        success: function (mydata) {
            console.log(mydata);
            mydata = JSON.parse(mydata);
            console.log(mydata);
            console.log(mydata.pagelist);
            if (mydata.status == "20006") {
                window.location.href = "../error.jsp";
            }
            else {
                //分页需要的参数
                up = mydata.up;
                next = mydata.next;
                allpages = mydata.allpages;
                current = mydata.current;
                allcount = mydata.allcount;
                $.each(mydata.pagelist, function (index, item) {
                    //if (index != null) {

                    var srt = '<tr><td>' + item["PID"] + '</td>';
                    srt += '<td>' + item["PNAME"] + '</td>';
                    srt += '<td>' + item["PREMARK"] + '</td>';
                    if (item["PFLAG"] == 0) {
                        srt += '<td><a href="#" onclick="getHuiFu(' + current + ',' + item["PID"] + ')" class="backdel">恢复部门</a> <td><a href="#" class="backdel"></a></td> </td>';
                    } else {
                        srt += '<td><a href="#" class="backdel"></a></td> <td><a href="#" onclick="mydel(' + current + ',' + item["PID"] + ')" class="backdel">撤销部门</a></td>';
                    }


                    $(".tablelist").append(srt);
                    //}

                });
                //加尾巴

                $(".pagin > .message").empty().append('统计：共<i class="blue"> ' + mydata.allcount + '</i> 条记录， 共<i class="blue"> ' + mydata.allpages + ' </i>页，当前显示第&nbsp;<i class="blue">' + mydata.current + '/' + mydata.allpages + '&nbsp;</i>页');
                $(".pagin > .message").append('<ul class="paginList">');
                $(".paginList").append('<li onclick="getAll1(9999,1)" class="paginItem"><a href="javascript:void(0)" class="first">首页</a></li>');
                $(".paginList").append('<li onclick="getAll1(9999,' + (mydata.current - 1) + ')" class="paginItem"><a href="javascript:void(0)" class="up">上一页</a></li>');
                $(".paginList").append('<li onclick="getAll1(9999,' + (mydata.current + 1) + ')"  class="paginItem"><a href="javascript:void(0)" class="next">下一页</a></li>');
                $(".paginList").append('<li onclick="getAll1(9999,' + mydata.allpages + ')" class="paginItem"><a href="javascript:void(0)" class="last">尾页</a></li>');
                $(".pagin > .message").append('<SPAN style="float: right;margin-top:8px;"> 转到第 <select class=select></select> 页</SPAN>');



                //给下拉框赋值
                for (var i = 1; i <= allpages; i++) {
                    $(".select").append("<option value='" + i + "'>" + i + "</option>");
                }
                //你当前正处在哪一页，就应该让几选中
                //你当前正处在哪一页，就应该让几选中
                $(".select option:eq(" + (parseInt(current) - 1) + ")").attr('selected', true);


            }
        }
    });
    if (state == 1) {
        layer.msg('恢复成功！', { icon: 6, time: 3000 });
    } else if (state == 0) {
        layer.msg('撤销成功！', { icon: 6, time: 3000 });
    } else if (state == 20009) {
        parent.layer.msg('添加成功！', { icon: 6, time: 3000 });
    } else if (state == 20010) {
        parent.layer.msg('添加失败', { icon: 2, time: 3000 });
    }
}

/**************************************************/
function getFirst() {
    $(".first").live("click", function () {
        getAll(1, pflag);
    });
}

function getUp() {
    $(".up").live("click", function () {
        getAll(up, pflag);
    });
}
function getNext() {
    $(".next").live("click", function () {
        getAll(next, pflag);
    });
}
function getLast() {
    $(".last").live("click", function () {
        getAll(allpages, pflag);
    });
}
function getZhan() {
    $(".select").live("change", function () {
        getAll($(".select").val(), pflag);
    });
}
/********************************************/
//添加部门
function addPart() {
    //点击添加按钮的绑定cilck事件	
    $(".addPart").bind("click", function () {
        layer.open({
            type: 2,
            title: "添加部门",
            fix: false,
            shadeClose: true,
            area: ['300px', '300px'],
            content: '/Department/Add',
            skin: 'layui-layer-lan',
            shift: 4, //动画类型
            //弹出来后，设定层出现的位置
            success: function (layero, index) {
                layer.style(index, {
                    width: '500px',
                    height: '300px',
                    top: '100px',
                    left: ($(window).width() - 500) / 2
                });
            },
            //层被销毁回调
            end: function () {
                getAll(current, 0);
            }
        });
    });
};
/**************************************************/


/************************弹出修改页面****************************/
function outupdate() {
    $(".myupp").live("click", function () {
        var pid = $(this).parents("tr").children("td").eq(0).text();
        layer.open({
            type: 2,
            title: '修改部门',
            fix: false,
            shadeClose: true,
            area: ['300px', '300px'],
            content: $webName + '/part/upp.jsp?pid=' + pid,
            skin: 'layui-layer-lan',
            shift: 4, //动画类型
            //弹出来后，设定层出现的位置
            success: function (layero, index) {
                layer.style(index, {
                    width: '500px',
                    height: '300px',
                    top: '100px',
                    left: ($(window).width() - 500) / 2
                });
            },
            //层被销毁回调
            end: function () {
                getAll(current, 0);
            }
        });
    });
}
/*********************************************/
/**********************删除********************/




/**********************************************************/
function mydelAll() {
    $(".delPart").bind("click", function () {
        $(".tablelist,.tablelist th").css("text-align", "center");
        getAll(1, 1);
        $(".addPart").hide();
        $(".delPart").hide();
        $(".backPart").show();
    });
}
function getBack() {
    $(".backPart").bind("click", function () {
        $(".tablelist,.tablelist th").css("text-align", "center");
        getAll(1, 0);
        $(".addPart").show();
        $(".delPart").show();
        $(".backPart").hide();
    });
}
function mydel(current, pid) {

    //var pid = $(this).parents("tr").children("td").eq(0).text();
    layer.confirm('你确定要撤销吗？',
            {
                btn: ['确定', '取消'],
                title: '撤销',
                skin: 'layui-layer-lan',
                shift: 4, //动画类型
                shaedClose: true,
                top: '30px',
                left: ($(window).width() - 400) / 2
            }
           , function () {
               $.post('/Department/edtDpt', { pid: pid, state: 0 }, function (data) {
                   data = JSON.parse(data);
                   if (data.status == 20007) {
                       layer.msg('撤销成功！', { icon: 6, time: 3000 });
                       getAll1(0, current)
                   }
                   else {
                       layer.msg('撤销失败！', { icon: 6, time: 3000 });
                   }
               }, 'json');
           }
             , function () {
                 //    
             });
}
function getHuiFu(current,pid) {
    //var pid = $(this).parents("tr").children("td").eq(0).text();
    layer.confirm('你确定要恢复此部门吗？',
            {
                btn: ['确定', '取消'],
                title: '恢复',
                skin: 'layui-layer-lan',
                shift: 4, //动画类型
                shadeClose: true,
                top: '30px',
                left: ($(window).width() - 400) / 2
            }
           , function () {
               $.post('/Department/edtDpt', { pid: pid, state: 1 }, function (data) {
                   data = JSON.parse(data);
                   if (data.status == 20007) {
                       layer.msg('恢复成功！', { icon: 6, time: 3000 });
                       getAll1(1, current)
                   }
                   else {
                       layer.msg('恢复失败！', { icon: 6, time: 3000 });
                   }
               }, 'json');
           }
             , function () {
                 //    
             });
}

function sleep(numberMillis) {
    var now = new Date();
    var exitTime = now.getTime() + numberMillis;
    while (true) {
        var now = new Date();
        nowtime = now.getTime() + 1;
        if (nowtime > exitTime) {
            window.location.reload();
            return;
        }
    }
}