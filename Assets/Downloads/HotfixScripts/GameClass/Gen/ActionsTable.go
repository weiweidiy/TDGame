/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/

package Configs

import (
    "encoding/json"
    "fmt"
    "os"
)

var ActionsTableData ActionsTable

type ActionsTable struct {
    AllData map[int32]*ActionsCfgData
}

type ActionsCfgData struct {
    Uid string  //唯一标识
    Triggers []string  //触发器
    Finder string  //查找器
    FinderArgs float32  //查找器参数
    Formula string  //公示计算器
    FormulaArgs []float32  //执行器参数
    Executors []string  //执行器
}

func LoadActionsTable(pDir string) {
    file, err := os.ReadFile(pDir + `/ActionsTable.json`)
    if err != nil {
        panic(fmt.Sprintf("Load [ActionsTable] Failed. {%s}", err))
    }

    err = json.Unmarshal(file, &ActionsTableData)
    if err != nil {
        panic(fmt.Sprintf("Unmarshal [ActionsTable] Failed. {%s}", err))
        return
    }
}

func GetActionsCfgData(id int32) *ActionsCfgData {
    data, have := ActionsTableData.AllData[id]
    if have {
        return data
    }
    return nil
}
