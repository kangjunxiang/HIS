USE [trasen_test]
GO
/****** Object:  StoredProcedure [dbo].[SP_ZYHS_YPFY_SELECT]    Script Date: 11/27/2014 14:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[SP_ZYHS_YPFY_SELECT]
(
	@TLFS INT, 
	@MSG_TYPE INT, 
	@DEPTLY BIGINT, 
	@WARDID VARCHAR(4),
	@INPATIENT_ID UNIQUEIDENTIFIER,
	@BABY_ID BIGINT,
	@EXECDEPT_ID BIGINT
) 
AS
/*--------------------------------------------------------------------------
作者：TANY
说明：住院护士站-药品统领信息查询
日期：2009-07-30
参数：
  @TLFS INT,        --统领方式（0=普通1=缺药2=重新发送3=出院代药4=因为延期没有退药，所以不能统领5=处方领药  ,9=暂存药（add by zouchihua 2012-3-09））
  @MSG_TYPE INT,    --消息类型（0=普通1=退药）
  @DEPTLY BIGINT,   --病区科室
  @WARDID           --病区
  @EXECDEPT_ID
修改：
Modify by zouchihua  增加了虚拟库存
Mofify by zouchihua 2012-3-10 增加了9=暂存药，多个病人显示姓名和床号
Mofify by zouchihua 2012-3-20 增加了统领方式 把退药的tlfs=9 放到普通里面
--------------------------------------------------------------------------*/

if (@WARDID='') set @WARDID='-1'  --jianqg 2012-4-27 因为 WARDID 在数据库 是整型数据，所以空串会报错
SET NOCOUNT ON
declare @str varchar(max)
declare @CFG6035 INT

declare @warddept varchar(1000) --Modify By tany 2013-03-03 
--
set @warddept=''
select @warddept=@warddept+case when @warddept='' then '' else ',' end+convert(varchar,dept_id) from jc_wardrdept where ward_id=@wardid

if @warddept=''
   set @warddept='0'
SET @CFG6035=isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6035),0)
IF @INPATIENT_ID <> DBO.FUN_GETEMPTYGUID()
BEGIN
set @str='SELECT 0 序号,CAST(1 AS SMALLINT) 选,c.INPATIENT_ID,
		COALESCE((SELECT NAME FROM YP_TLFL WHERE CODE=B.TLFL),''其它'') 类型,
		S_YPJX 剂型,YPPM 品名,YPSPM 商品名,YPGG 规格,S_SCCJ 厂家,
		CAST(COST_PRICE AS FLOAT) 单价,
		CAST(ROUND((case when '+CAST ( @CFG6035 as varchar(10))+'=0 then  KCL else xnkcl end),2) AS FLOAT) 库存数,CAST(A.NUM*A.DOSAGE AS FLOAT) 数量,A.UNIT 单位,  
		CAST(SDVALUE AS FLOAT) 金额,SHH 货号,B.CJID,C.BED_NO 床号,  
		C.NAME 姓名, C.INPATIENT_NO 住院号,A.DEPT_ID,
		'''' APPLY_ID,'''' APPLY_DATE,CHARGE_BIT,C.WARD_ID,A.ID ZY_ID,UNITRATE,
		CAST((A.NUM*A.DOSAGE*B.DWBL/UNITRATE) AS FLOAT) YPSL,  
		ZXDW,DWBL,B.PFJ/UNITRATE 批发价,
		CAST((B.PFJ*A.NUM*A.DOSAGE/UNITRATE) AS FLOAT) 批发金额,
		B.TLFL 统领分类,B.YPJX,ISNULL(F.ID,0) YPYF,F.NAME 药品用法,A.DEPT_LY,A.PRESC_DATE,B.TLFL,E.MNGTYPE,B.YPLX 
	FROM ZY_FEE_SPECI A(NOLOCK) 
	INNER JOIN VI_YF_KCMX B(NOLOCK) 
	ON A.XMID=B.CJID AND A.XMLY=1 AND A.EXECDEPT_ID=B.DEPTID
	INNER JOIN VI_ZY_VINPATIENT_ALL C 
	ON A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID 
	left JOIN ZY_ORDERRECORD E ON A.ORDER_ID=E.ORDER_ID
	LEFT JOIN JC_USAGEDICTION F ON E.ORDER_USAGE=F.NAME
	WHERE A.INPATIENT_ID='''+CAST( @INPATIENT_ID as varchar(40))+''' AND A.BABY_ID='+cast(@BABY_ID as varchar(10))+'
		AND ISNULL(APPLY_ID,DBO.FUN_GETEMPTYGUID())=DBO.FUN_GETEMPTYGUID()--Modify By Tany 2011-01-18
		AND FY_BIT=0 
		AND A.STATITEM_CODE IN (''01'',''02'') '
	if  @MSG_TYPE=0
	   set @str=@str+' and TLFS='+CAST(@TLFS as varchar(10)) +''
	 if @MSG_TYPE=1 and @TLFS=0
	   set @str=@str+' and TLFS in(0,9)'
	 if @MSG_TYPE=1 and @TLFS!=0   
	   set @str=@str+' and TLFS='+CAST(@TLFS as varchar(10)) +''
		--AND ((@MSG_TYPE=0 and TLFS=@TLFS ) or(@MSG_TYPE=1 and @TLFS=0  and TLFS in(0,9) )
		--    or (@MSG_TYPE=1 and @TLFS!=0 and TLFS=@TLFS) ) 
	set @str =@str+' AND EXECDEPT_ID='+ CAST( @EXECDEPT_ID as varchar(10)) + 
		' AND (('+CAST ( @MSG_TYPE as varchar(10))+'=0 AND CZ_FLAG IN (0,1,3)) OR ('+CAST ( @MSG_TYPE as varchar(10))+'=1 AND CZ_FLAG=2))
		AND A.DELETE_BIT=0
		AND (a.DEPT_LY='+CAST ( @DEPTLY as varchar(10))+'  OR a.DEPT_LY IN ('+@warddept+'))
	ORDER BY YLFL,S_YPJX,YPSPM,COST_PRICE '
	--SELECT (@str)
	exec (@str)
END
ELSE
BEGIN
	/*Modify By Tany 2011-01-18 换种写法
	SELECT 0 序号,CAST(1 AS SMALLINT) 选,
		COALESCE((SELECT NAME FROM YP_TLFL WHERE CODE=B.TLFL),'其它') 类型,
		S_YPJX 剂型,YPPM 品名,YPSPM 商品名,YPGG 规格,S_SCCJ 厂家,
		CAST(COST_PRICE AS FLOAT) 单价,
		CAST(ROUND(KCL,2) AS FLOAT) 库存数,CAST(A.NUM*A.DOSAGE AS FLOAT) 数量,A.UNIT 单位,  
		CAST(SDVALUE AS FLOAT) 金额,SHH 货号,B.CJID,C.BED_NO 床号,  
		C.NAME 姓名, C.INPATIENT_NO 住院号,A.DEPT_ID,
		'' APPLY_ID,'' APPLY_DATE,CHARGE_BIT,C.WARD_ID,A.ID ZY_ID,UNITRATE,
		CAST((A.NUM*A.DOSAGE*B.DWBL/UNITRATE) AS FLOAT) YPSL,  
		ZXDW,DWBL,B.PFJ/UNITRATE 批发价,
		CAST((B.PFJ*A.NUM*A.DOSAGE/UNITRATE) AS FLOAT) 批发金额,
		B.TLFL 统领分类,B.YPJX,ISNULL(F.ID,0) YPYF,F.NAME 药品用法,A.DEPT_LY  
	FROM ZY_FEE_SPECI A(NOLOCK) 
	INNER JOIN VI_YF_KCMX B(NOLOCK) 
	ON A.XMID=B.CJID AND A.XMLY=1 AND A.EXECDEPT_ID=B.DEPTID
	INNER JOIN VI_ZY_VINPATIENT_ALL C 
	ON A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID 
--	INNER JOIN YP_YPJX D ON D.ID=B.YPJX
	INNER JOIN ZY_ORDERRECORD E ON A.ORDER_ID=E.ORDER_ID
	LEFT JOIN JC_USAGEDICTION F ON E.ORDER_USAGE=F.NAME
	WHERE --(APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) 
		ISNULL(APPLY_ID,DBO.FUN_GETEMPTYGUID())=DBO.FUN_GETEMPTYGUID()--Modify By Tany 2011-01-18
		AND FY_BIT=0 
		AND A.STATITEM_CODE IN ('01','02')
		AND TLFS=@TLFS AND EXECDEPT_ID=@EXECDEPT_ID
		AND ((@MSG_TYPE=0 AND CZ_FLAG IN (0,1,3)) OR (@MSG_TYPE=1 AND CZ_FLAG=2))
		AND A.DELETE_BIT=0
		AND (DEPT_LY=@DEPTLY OR DEPT_LY IN (SELECT DEPT_ID FROM JC_WARDRDEPT WHERE WARD_ID=@WARDID))
	ORDER BY YLFL,S_YPJX,YPSPM,COST_PRICE
	*/
	--Modify By Tany 2011-01-18 去除病人信息
	
 set @str ='SELECT 0 ''序号'',CAST(1 AS SMALLINT) 选,'''' 床号,'''' 姓名,dbo.FUN_GETEMPTYGUID() INPATIENT_ID,
		COALESCE((SELECT NAME FROM YP_TLFL WHERE CODE=B.TLFL),''其它'') 类型,
		S_YPJX 剂型,YPPM 品名,YPSPM 商品名,YPGG 规格,S_SCCJ 厂家,
		CAST(COST_PRICE AS FLOAT) 单价,
		CAST(ROUND((case when '+CAST ( @CFG6035 as varchar(10))+'=0 then  KCL else xnkcl end),2) AS FLOAT)  库存数,CAST(A.NUM*A.DOSAGE AS FLOAT) 数量,A.UNIT 单位,  
		CAST(SDVALUE AS FLOAT) 金额,SHH 货号,B.CJID,A.DEPT_ID,
		'''' APPLY_ID,'''' APPLY_DATE,CHARGE_BIT,A.ID ZY_ID,UNITRATE,
		CAST((A.NUM*A.DOSAGE*B.DWBL/UNITRATE) AS FLOAT) YPSL,  
		ZXDW,DWBL,B.PFJ/UNITRATE 批发价,
		CAST((B.PFJ*A.NUM*A.DOSAGE/UNITRATE) AS FLOAT) 批发金额,
		B.TLFL 统领分类,B.YPJX,ISNULL(F.ID,0) YPYF,F.NAME 药品用法,A.DEPT_LY ,A.PRESC_DATE,B.TLFL,E.MNGTYPE,B.YPLX 
	FROM ZY_FEE_SPECI A(NOLOCK) 
	INNER JOIN VI_YF_KCMX B(NOLOCK) 
	ON A.XMID=B.CJID AND A.XMLY=1 AND A.EXECDEPT_ID=B.DEPTID and b.deptid='+CAST( @EXECDEPT_ID as varchar(10))+'
	left  JOIN ZY_ORDERRECORD E ON A.ORDER_ID=E.ORDER_ID
	INNER JOIN ZY_YPTL G ON A.ID=G.FEEID
	LEFT JOIN JC_USAGEDICTION F ON E.ORDER_USAGE=F.NAME
	WHERE   G.FY_BIT=0  '
	 
	 if  @MSG_TYPE=0  
	   set @str=@str+' and G.TLFS='+CAST(@TLFS as varchar(10)) +''
	 if @MSG_TYPE=1 and @TLFS=0
	   set @str=@str+' and G.TLFS in(0,9)' 
	 if @MSG_TYPE=1 and @TLFS!=0   
	   set @str=@str+' and G.TLFS='+CAST(@TLFS as varchar(10)) +''
		set @str=@str+ ' AND G.EXECDEPT_ID='+CAST( @EXECDEPT_ID as varchar(10))+' 
		AND (('+CAST ( @MSG_TYPE as varchar(10))+'=0 AND G.CZ_FLAG IN (0,1,3)) OR ('+CAST ( @MSG_TYPE as varchar(10))+'=1 AND G.CZ_FLAG=2))
		AND A.DELETE_BIT=0 AND G.DELETE_BIT=0
		AND (G.DEPT_LY='+CAST ( @DEPTLY as varchar(10))+' OR G.DEPT_LY IN ('+@warddept+'))
	ORDER BY YLFL,S_YPJX,YPSPM,COST_PRICE '
	  
	exec (@str)
	
END
