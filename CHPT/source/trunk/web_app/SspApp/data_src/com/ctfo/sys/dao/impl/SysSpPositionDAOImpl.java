package com.ctfo.sys.dao.impl;

import org.springframework.orm.ibatis.support.SqlMapClientDaoSupport;

import com.ctfo.sys.beans.SysSpPosition;
import com.ctfo.sys.dao.SysSpPositionDAO;

public class SysSpPositionDAOImpl extends SqlMapClientDaoSupport implements SysSpPositionDAO {

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public SysSpPositionDAOImpl() {
		super();
	}

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public void insert(SysSpPosition record) {
		getSqlMapClientTemplate().insert("SYS_SP_POSITION.abatorgenerated_insert", record);
	}

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public int updateByPrimaryKey(SysSpPosition record) {
		int rows = getSqlMapClientTemplate().update("SYS_SP_POSITION.abatorgenerated_updateByPrimaryKey", record);
		return rows;
	}

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public int updateByPrimaryKeySelective(SysSpPosition record) {
		int rows = getSqlMapClientTemplate().update("SYS_SP_POSITION.abatorgenerated_updateByPrimaryKeySelective", record);
		return rows;
	}
	

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public SysSpPosition selectByPrimaryKey(String positionCode) {
		SysSpPosition key = new SysSpPosition();
		key.setPositionCode(positionCode);
		SysSpPosition record = (SysSpPosition) getSqlMapClientTemplate().queryForObject("SYS_SP_POSITION.abatorgenerated_selectByPrimaryKey", key);
		return record;
	}

	/**
	 * This method was generated by Abator for iBATIS. This method corresponds to the database table SYS_SP_POSITION
	 * @abatorgenerated  Mon Mar 24 16:46:48 CST 2014
	 */
	public int deleteByPrimaryKey(String positionCode) {
		SysSpPosition key = new SysSpPosition();
		key.setPositionCode(positionCode);
		int rows = getSqlMapClientTemplate().delete("SYS_SP_POSITION.abatorgenerated_deleteByPrimaryKey", key);
		return rows;
	}
}