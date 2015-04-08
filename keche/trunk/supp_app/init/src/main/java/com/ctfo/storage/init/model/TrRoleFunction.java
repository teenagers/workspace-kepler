package com.ctfo.storage.init.model;



import java.io.Serializable;


@SuppressWarnings("serial")
public class TrRoleFunction extends BaseModel implements Serializable{
    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.ROLE_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private String roleId;

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.FUN_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private String funId = "";

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.CREATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private String createBy ="";

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.CREATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private Long createTime =-1l;

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.UPDATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private String updateBy ="";

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.UPDATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private Long updateTime =-1l;

    /**
     * This field was generated by Abator for iBATIS.
     * This field corresponds to the database column TR_ROLE_FUNCTION.ENABLE_FLAG
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    private String enableFlag = "";

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.ROLE_ID
     *
     * @return the value of TR_ROLE_FUNCTION.ROLE_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public String getRoleId() {
        return roleId;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.ROLE_ID
     *
     * @param roleId the value for TR_ROLE_FUNCTION.ROLE_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setRoleId(String roleId) {
        this.roleId = roleId;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.FUN_ID
     *
     * @return the value of TR_ROLE_FUNCTION.FUN_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public String getFunId() {
        return funId;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.FUN_ID
     *
     * @param funId the value for TR_ROLE_FUNCTION.FUN_ID
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setFunId(String funId) {
        this.funId = funId;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.CREATE_BY
     *
     * @return the value of TR_ROLE_FUNCTION.CREATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public String getCreateBy() {
        return createBy;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.CREATE_BY
     *
     * @param createBy the value for TR_ROLE_FUNCTION.CREATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setCreateBy(String createBy) {
        this.createBy = createBy;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.CREATE_TIME
     *
     * @return the value of TR_ROLE_FUNCTION.CREATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public Long getCreateTime() {
        return createTime;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.CREATE_TIME
     *
     * @param createTime the value for TR_ROLE_FUNCTION.CREATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setCreateTime(Long createTime) {
        this.createTime = createTime;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.UPDATE_BY
     *
     * @return the value of TR_ROLE_FUNCTION.UPDATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public String getUpdateBy() {
        return updateBy;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.UPDATE_BY
     *
     * @param updateBy the value for TR_ROLE_FUNCTION.UPDATE_BY
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setUpdateBy(String updateBy) {
        this.updateBy = updateBy;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.UPDATE_TIME
     *
     * @return the value of TR_ROLE_FUNCTION.UPDATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public Long getUpdateTime() {
        return updateTime;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.UPDATE_TIME
     *
     * @param updateTime the value for TR_ROLE_FUNCTION.UPDATE_TIME
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setUpdateTime(Long updateTime) {
        this.updateTime = updateTime;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method returns the value of the database column TR_ROLE_FUNCTION.ENABLE_FLAG
     *
     * @return the value of TR_ROLE_FUNCTION.ENABLE_FLAG
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public String getEnableFlag() {
        return enableFlag;
    }

    /**
     * This method was generated by Abator for iBATIS.
     * This method sets the value of the database column TR_ROLE_FUNCTION.ENABLE_FLAG
     *
     * @param enableFlag the value for TR_ROLE_FUNCTION.ENABLE_FLAG
     *
     * @abatorgenerated Sat Oct 15 12:24:24 CST 2011
     */
    public void setEnableFlag(String enableFlag) {
        this.enableFlag = enableFlag;
    }
}