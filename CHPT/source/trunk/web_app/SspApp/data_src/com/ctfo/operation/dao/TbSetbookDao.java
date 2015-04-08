package com.ctfo.operation.dao;

import com.ctfo.archives.beans.SysSetbook;
import com.ctfo.local.dao.GenericIbatisDao;
import com.ctfo.operation.beans.TbSetbook;

public interface TbSetbookDao extends GenericIbatisDao<TbSetbook, String>{

	public SysSetbook selectPKByCom(String comId);
}
