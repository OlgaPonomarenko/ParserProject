using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ParseProject
{
    public class Parser
    {
        EntityReader reader;
        ComponentEntity component = new ComponentEntity();

        public Parser(string _fileName)
        {
            reader = new EntityReader(_fileName);
        }

        public void ParseFile(ComponentEntity _component)
        {
            component = _component;
            reader.ReadFile();
            reader.FileToList();
            reader.GetEntity(component);
        }       
    }

    public class ComponentEntity
    {
        public string componentName { get; set; }
        public List<Gate> gateIn = new List<Gate>();
        public List<Gate> gateOut = new List<Gate>();

        public ComponentEntity()
        {

        }

        public void AddGateIn(Gate _gateIn)
        {
            gateIn.Add(_gateIn);
        }

        public void AddGateOut(Gate _gateOut)
        {
            gateOut.Add(_gateOut);
        }

        public void AddGate(Gate _gate)
        {
            if (_gate.gateAccessMode == "in")
                AddGateIn(_gate);

            if (_gate.gateAccessMode == "out")
                AddGateOut(_gate);
        }

        public void GetCopyOfGates(ref List<Gate> _gateIn, ref List<Gate> _gateOut)
        {
            int amountOfElement = gateIn.Count();
            Gate[] tempGateIn = new Gate[amountOfElement];
            gateIn.CopyTo(tempGateIn);

            for (int i = 0; i < amountOfElement; i++)
                _gateIn.Add(tempGateIn[i]);

            amountOfElement = gateOut.Count();
            Gate[] tempGateOut = new Gate[amountOfElement];
            gateOut.CopyTo(tempGateOut);

            for (int i = 0; i < amountOfElement; i++)
                _gateOut.Add(tempGateOut[i]);           
        }

        public void DeleteComponentOnName(string _gateName)

        {
            int indexOfComp = -1;
            foreach(Gate entry in gateIn)
            {
                if (entry.gateName == _gateName)
                    indexOfComp = gateIn.IndexOf(entry);
            }

            if (indexOfComp > -1)
                gateIn.Remove(gateIn[indexOfComp]);

            indexOfComp = -1;
            foreach (Gate entry in gateOut)
            {
                if (entry.gateName == _gateName)
                    indexOfComp = gateOut.IndexOf(entry);
            }
           
            if (indexOfComp > -1)
                gateOut.Remove(gateOut[indexOfComp]);
        }


        public void ComponentOutput()
        {
            MessageBox.Show("\n\nComponent " + componentName + "\r\nGatesIn");

            foreach (Gate entry in gateIn)
                entry.GateOutput();
            MessageBox.Show("\nGatesOut");
            foreach (Gate entry in gateOut)
                entry.GateOutput();
        }
    }


    public class Gate
    {
        public string gateName { get; set; }
        public string gateType { get; set; }
        public string gateAccessMode { get; set; }
        public int dimension { get; set; }

        
        public Gate()
        {

        }

        public Gate(string _gateName, string _gateType, string _gateAccessMode)
        {
            gateName = _gateName;
            gateType = _gateType;
            gateAccessMode = _gateAccessMode;
            dimension = 0;
        }

        public Gate(string _gateName, string _gateType, string _gateAccessMode, int _dimension)
        {
            gateName = _gateName;
            gateType = _gateType;
            gateAccessMode = _gateAccessMode;
            dimension = _dimension;
        }


        public void GateOutput()
        {
            string temp = "";
            temp += "\r\nGate";
            temp += "\r\ngateName = " + gateName;
            temp += "\r\ngateType = " + gateType;
            temp += "\r\ngateAccessMode = " + gateAccessMode;
            if(dimension>0)
            {
                temp += "\r\ndimension = " + dimension;
            }
            MessageBox.Show(temp);
        }

        
    }

    class EntityReader
    {
        FileInfo currentfile;
        public string fileContent { get; private set; }
        private char space = ' ';

        List<string> listContent = new List<string>();
        List<string> listEntity = new List<string>();

        List<string> contentIn = new List<string>();
        List<string> contentOut = new List<string>();


        public EntityReader(string _fileName)
        {
            if (_fileName == "")
                throw new ArgumentException("File's name is not entered. Please, enter file's name.");
            
            currentfile = new FileInfo(_fileName);
            if (!FileExist(currentfile))
                throw new ArgumentException("File is not exist. Please, enter file's name.");
        }

        public bool FileExist(FileInfo _file)
        {
            bool state = false;
            if (_file.Exists)
                state = true;
            return state;
        }


        public void ReadFile()
        {

            using (StreamReader sr = currentfile.OpenText())
            {
                fileContent = sr.ReadToEnd();
            }
        }

        public void FileToList()
        {

            foreach (string entry in fileContent.Split('\n'))
            {
                if (entry != "\r" && entry != "" && entry != "\n")
                {
                    foreach (string word in entry.Split(space))
                    {
                        foreach (string thisWord in word.Split('\t'))
                        {
                            string currentWord = thisWord;
                            string temp = "";

                            if (currentWord != string.Empty)
                            {
                                bool flag = false;
                                int indexT = 0;
                                for (int i = 0; i < currentWord.Count(); i++)
                                {
                                    if (currentWord[i] == '\t')
                                    {
                                        indexT = i;
                                        flag = true;
                                    }
                                }

                                if (flag)
                                {
                                    for (int j = indexT + 1; j < currentWord.Count(); j++)
                                        temp += currentWord[j];

                                    currentWord = temp;
                                }

                                listContent.Add(currentWord);
                            }
                        }
                    } 
                }
            }
        }

        public void GetEntity(ComponentEntity component)
        {
            int ingexOfEntity = 0;

            int indexOfPort = 0;

            int indexOfEnd = 0;

            string entityName = "";


            ingexOfEntity = listContent.IndexOf("entity");
            if (ingexOfEntity != 0)                           
                entityName = listContent[ingexOfEntity + 1];

            component.componentName = entityName;

            for (int i = 0; i < listContent.Count(); i++)
            {                
                if(listContent[i].Contains("port"))
                {
                    indexOfPort = i;
                    break;
                }
            }

            indexOfEnd = listContent.IndexOf("end");

            if (indexOfPort != 0 && indexOfEnd != 0)
            {
                for (int i = indexOfPort; i < indexOfEnd; i++)
                    listEntity.Add(listContent[i]);
            }
            
 
            int indexOfAccessMode = 0;

            string typeOfGate = "";

            int currentPos = 0;

            string accessMode = "";

            int dimension = 0;

            while (currentPos < listEntity.Count())
            {
                if (ContainWord(currentPos, ref accessMode))
                {
                    dimension = 0;
                    GetTypeOfGate(ref currentPos, out typeOfGate, ref indexOfAccessMode, accessMode, ref dimension);

                    List<string> listCurrentGate = new List<string>();

                    GetGates(currentPos, indexOfAccessMode, listCurrentGate);

                    foreach (string entry in listCurrentGate)
                    {
                        Gate gate = new Gate(entry, typeOfGate, accessMode);

                        if (dimension > 0)
                            gate.dimension = dimension;

                        component.AddGate(gate);
                    }

                    FindNextPart(indexOfAccessMode, ref currentPos);
                }
            }
        }

        public void GetTypeOfGate(ref int currentPos, out string typeOfGate, ref int indexOfAccessMode, string accessMode, ref int dimension)
        {
            typeOfGate = "";

            string stringWithAccessMode = string.Empty;

            foreach(string temp in listEntity)
            {
                if (temp.Contains(accessMode))
                    stringWithAccessMode = temp;
            }

            indexOfAccessMode = listEntity.IndexOf(accessMode, currentPos);

            if (indexOfAccessMode != 0)
            {
                typeOfGate = listEntity[indexOfAccessMode + 1];

                for (int i = 0; i < typeOfGate.Count(); i++)
                {
                    if (typeOfGate[i] == ';' || typeOfGate[i] == '(' || typeOfGate[i] == ')')
                    {
                        string tempString = "";
                        for (int j = 0; j < i; j++)
                            tempString += typeOfGate[j];
                        typeOfGate = tempString;
                        break;
                    }
                }

                int nextPartIndex = 0;
                FindNextPart(indexOfAccessMode, ref nextPartIndex);

                if (typeOfGate == "STD_LOGIC_VECTOR" || typeOfGate == "std_logic_vector")
                {
                    
                    int numberOne = -1;
                    int numberTwo = -1;                   
                    for (int i = indexOfAccessMode + 1; i < nextPartIndex; i++)
                        {
                        int currentNumber = -1;
                        bool flagBreak = false;
                        foreach (string partOfListEntity in listEntity[i].Split(space))
                        {
                            string stringWithNumbers = string.Empty;

                            for (int j = 0; j < partOfListEntity.Count(); j++)
                            {
                                string temp = string.Empty;
                                temp += listEntity[i][j];

                                if (Int32.TryParse(temp, out currentNumber))
                                {
                                    stringWithNumbers += temp;
                                }

                                if (temp == ";")
                                {
                                    flagBreak = true;
                                    break;
                                }

                                if (flagBreak)
                                    break;
                            }

                            if (Int32.TryParse(stringWithNumbers, out currentNumber))
                            {
                                if (numberOne < 0)
                                    numberOne = currentNumber;
                                else
                                    numberTwo = currentNumber;
                            }
                        }
                    }
                   
                    if(numberOne > -1 && numberTwo > -1)
                    {
                        if (numberOne > numberTwo)
                            dimension = numberOne - numberTwo + 1;
                        else
                            dimension = numberTwo - numberOne + 1;
                    }
                }
            }
        }


        public void FindNextPart(int indexOfAccessMode, ref int currentPos)
        {
            
            for (int k = indexOfAccessMode + 1; k < listEntity.Count(); k++)
            {
                bool flag = false;
                if (listEntity[k].Contains(";"))
                {
                    currentPos = k;
                    flag = true;
                    break;
                }

                if (k == listEntity.Count() - 1 && flag == false)
                    break;
            }
            currentPos++;
        }

        public void GetGates(int currentPos, int indexOfAccessMode, List<string> _listCurrentGate)
        {

            for (int i = currentPos; i < indexOfAccessMode; i++)
            {
                if (listEntity[i].Contains("\r") == false && listEntity[i].Contains("port") == false)
                {
                    string temp = string.Empty;
                    temp = listEntity[i];

                    for (int j = 0; j < temp.Count(); j++)
                    {
                        if ((temp[j] == ':' || temp[j] == ',' || temp[j] == '(') && j == temp.Count() - 1)
                            {                            
                            string tempString = "";
                            for (int k = 0; k < j; k++)
                                tempString += temp[k];
                            temp = tempString;
                            break;
                        }
                    }

                     for (int j = 0; j < temp.Count(); j++)
                     {
                        if ((temp[j] == ',' || temp[j] == '(') && j != temp.Count() - 1)
                        {
                            string tempString = "";
                            for (int k = j+1; k < temp.Count(); k++)
                                tempString += temp[k];
                            temp = tempString;
                            break;
                        }
                    }
                    if (temp != "")
                    {
                        _listCurrentGate.Add(temp);
                    }
                }
                else
                    currentPos++;
            }
        }


        public bool ContainWord(int currentPos, ref string accessMode)
        {
            bool flagExist = false;
            for (int i = currentPos; i < listEntity.Count(); i++)
            {
                if (listEntity[i] == "in")
                {
                    accessMode = "in";
                    flagExist = true;
                    break;
                }
                if (listEntity[i] == "out")
                {
                    accessMode = "out";
                    flagExist = true;
                    break;
                }
            }
            return flagExist;
        }
    }
}
