using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum StatusCodes
    {
        登陆成功=20001,
        登陆失败=20002,
        用户名不存在=20003,
        用户名存在 = 20004,
        列表查询成功 = 20005,
        列表查询失败 = 20006,
        部门修改成功 = 20007,
        部门修改失败 = 20008,
        部门添加成功 = 20009,
        部门添加失败 = 20010,
        角色查询成功 = 20011,
        角色查询失败 = 20012
    }
}
