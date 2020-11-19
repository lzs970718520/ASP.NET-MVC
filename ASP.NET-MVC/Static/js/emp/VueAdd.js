
axios.post('/Employee/ShowOptions', {})
    .then(function (data) {
        console.log(data);
        //Vue.component('todo-item', {
        //    props: ['todo'],
        //    template: '<option></option>'
        //})
        //var jsText= new Vue({
        //    el: "#jid",
        //    data: {
        //        groceryList: data.data.jsList
        //    }
        //})
        //var GetMsg= new Vue({
        //    el: ".selectinput",
        //    data: {
        //        PID: 3,
        //        groceryList: data.data.deptList
        //    },
        //    methods: {
        //        addEmp: function () {
        //            layer.msg(selected)
        //        }
        //    }
        //})
        var GetMsg2 = new Vue({
            el: ".formbody",
            data:{
                erealname: "",
                ename: "",
                epsw: "",
                etel: "",
                eaddress: "",
                eremark: "",
                PID: 0,
                JID: 0,
                dList: data.data.deptList,
                jList: data.data.jsList,
            },
            methods: {
                addEmp: function () {
                    var erealname = this.erealname;
                    var ename = this.ename;
                    var epsw = this.epsw;
                    var etel = this.etel;
                    var eaddress = this.eaddress;
                    var eremark = this.eremark;
                    var pid = this.PID;
                    var jid = this.JID;
                    axios.post('/Employee/addEmp', { EREALNAME: erealname, ENAME: ename, EPSW: epsw, ETEL: etel, EADDRESS: eaddress, EREMARK: eremark, PID: pid, JID: jid })
                     .then(function (data) {
                         console.log(data);
                         if (data.data.status == 20011) {
                             parent.layer.msg('添加成功！', { icon: 6, time: 3000 });
                             var index = parent.layer.getFrameIndex(window.name); //获取窗口索引(真正的关 )
                             parent.layer.close(index);
                         }
                     })
                     .catch(function(error){
                         //..
                     });
                }
            }
        })
    })
    .catch(function (error) {
        console.log(error);
    });
