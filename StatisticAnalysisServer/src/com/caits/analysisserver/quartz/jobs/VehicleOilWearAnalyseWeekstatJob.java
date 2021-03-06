package com.caits.analysisserver.quartz.jobs;

import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import com.caits.analysisserver.quartz.MyJob;
import com.caits.analysisserver.quartz.jobs.impl.VehicleOilWearAnalyseWeekstatJobdetail;
import com.caits.analysisserver.utils.CDate;

/**
 * 管理报表--单车油耗分析日报
 * 运行频率：每日车辆日统计结果生成后执行  3点10分
 * @author yujch
 */
public class VehicleOilWearAnalyseWeekstatJob extends MyJob {
	
	private String jobName = "VehicleOilWearAnalyseWeekstatJob";
	
	@Override
	public String getJobName() {
		// TODO Auto-generated method stub
		return this.jobName;
	}
	
/*	@Override
	public int executePrev() {
		// TODO Auto-generated method stub
		return JobMonitor.getInstance().queryJobDependStatus("OrgAlarmDaystatJob");
	}*/

	/*
	 * 每日统计前一日数据
	 * 
	 * @see org.quartz.Job#execute(org.quartz.JobExecutionContext)
	 */
	@Override
	public int executeJob(JobExecutionContext arg0) throws JobExecutionException {
		// TODO Auto-generated method stub
		int previousweek = CDate.getPreviousWeek();
		int month = CDate.getMonthOfYearByCurrentDate();
		int year = CDate.getCurrentYear();
		if (month==0&&previousweek>4){
			year = CDate.getPreviousYear();
		}
		
		VehicleOilWearAnalyseWeekstatJobdetail vodJobDetail = new VehicleOilWearAnalyseWeekstatJobdetail(year,previousweek);
		
		return vodJobDetail.executeStatRecorder();
	}

	
/*
	@Override
	public int executeEnd(int execFlag) {
		// TODO Auto-generated method stub
		return JobMonitor.getInstance().updateJobRunningMonitor("OrgAlarmDaystatJob", ""+execFlag, new Date());
	}*/
}
