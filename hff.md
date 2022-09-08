参考类库    
HFF-Code-CSharp.dll（2853 KB，2021-10-11）    
Assembly-CSharp.dll（2388 KB，2022-04-13）    
     
使用 Ctrl + F 搜索    
    
$\color{red} {red} $

<table>
    <tr>
        <th width="60">序号</th>
        <th width="200">组件名</th>
        <th width="600">描述</th>
    </tr>
    <tr>
        <td colspan="3"><font color="gray">Signal系列</font></td>
    </tr>
    <tr>
        <td>1</td>
        <td>Signal Accumulate<br><font color="red">IReset接口</font></td>
        <td>数值累计。<br>每秒累计output：input × CPS。勾选clamp max(min)，则当累计到max(min) value时停止累计；勾选reset，则可以RESET。当RESET时，清零累计数值。</td>
    </tr>
    <tr>
        <td>2</td>
        <td>Signal Add Impulse</td>
        <td>添加瞬时力。<br>
当input有信号时，给body施加一个延force向量方向，绕torque向量的力；勾选AITC，则该力也将作用于body的子物体。（该力只能触发一次）
    </td>
    </tr>
    <tr>
        <td>3</td>
        <td>Signal Angle</td>
        <td>角度→信号。<br>
将joint的旋转角度限制在from angle~to angle之间，并将from angle~to angle的角度线性对应到0~1（勾选signed output则为-1~1）上输出。
</td>
    </tr>
    <tr>
        <td>4</td>
        <td>Signal Angular Velocity</td>
        <td>角速度→信号。<br>
FV, FDV, TDV, TV将输出数值的-1~1分成了三部分<br>
①当FV ≤ 角速度 ≤ FDV时：随着角速度增大，输出将由-1逐渐变为0；<br>
②当FDV ≤ 角速度 ≤ TDV时：随着角速度增大，输出将始终保持0；<br>
③当TDV ≤ 角速度 ≤ TV时：随着角速度增大，输出将由0逐渐变为1。<br>
即：<br>
当物体角速度 < FDV时：<br>
输出：-InverseLerp(FDV, FV, 物体角速度)<br>
当物体角速度 > TDV时：<br>
输出：InverseLerp(TDV, TV, 物体角速度)<br>
（InverseLerp计算公式见下方）<br>
若想消除②，只需让FDV = TDV = 0即可，此时0~TV将线性对应-1~1，不会在0处停留。
</td>
    </tr>
    <tr>
        <td>5</td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>6</td>
        <td></td>
        <td></td>
    </tr>
        <td>7</td>
        <td></td>
        <td></td>
    </tr>
        <td>8</td>
        <td></td>
        <td></td>
    </tr>
        <td>9</td>
        <td></td>
        <td></td>
    </tr>
        <td>10</td>
        <td></td>
        <td></td>
    </tr>
        <td>11</td>
        <td></td>
        <td></td>
    </tr>
        <td>12</td>
        <td></td>
        <td></td>
    </tr>
        <td>13</td>
        <td></td>
        <td></td>
    </tr>
        <td>14</td>
        <td></td>
        <td></td>
    </tr>
        <td>15</td>
        <td></td>
        <td></td>
    </tr>
        <td>16</td>
        <td></td>
        <td></td>
    </tr>
        <td>17</td>
        <td></td>
        <td></td>
    </tr>
        <td>18</td>
        <td></td>
        <td></td>
    </tr>
        <td>19</td>
        <td></td>
        <td></td>
    </tr>
        <td>20</td>
        <td></td>
        <td></td>
    </tr>
        <td>21</td>
        <td></td>
        <td></td>
    </tr>
        <td>22</td>
        <td></td>
        <td></td>
    </tr>
        <td>23</td>
        <td></td>
        <td></td>
    </tr>
        <td>24</td>
        <td></td>
        <td></td>
    </tr>
        <td>25</td>
        <td></td>
        <td></td>
    </tr>
        <td>26</td>
        <td></td>
        <td></td>
    </tr>
        <td>27</td>
        <td></td>
        <td></td>
    </tr>
        <td>28</td>
        <td></td>
        <td></td>
    </tr>
        <td>29</td>
        <td></td>
        <td></td>
    </tr>
        <td>30</td>
        <td></td>
        <td></td>
    </tr>
        <td>31</td>
        <td></td>
        <td></td>
    </tr>
        <td>32</td>
        <td></td>
        <td></td>
    </tr>
        <td>33</td>
        <td></td>
        <td></td>
    </tr>
        <td>34</td>
        <td></td>
        <td></td>
    </tr>
        <td>35</td>
        <td></td>
        <td></td>
    </tr>
        <td>36</td>
        <td></td>
        <td></td>
    </tr>
        <td>37</td>
        <td></td>
        <td></td>
    </tr>
        <td>38</td>
        <td></td>
        <td></td>
    </tr>
        <td>39</td>
        <td></td>
        <td></td>
    </tr>
        <td>40</td>
        <td></td>
        <td></td>
    </tr>
        <td>41</td>
        <td></td>
        <td></td>
    </tr>
        <td>42</td>
        <td></td>
        <td></td>
    </tr>
        <td>43</td>
        <td></td>
        <td></td>
    </tr>
        <td>44</td>
        <td></td>
        <td></td>
    </tr>
        <td>45</td>
        <td></td>
        <td></td>
    </tr>
        <td>46</td>
        <td></td>
        <td></td>
    </tr>
        <td>47</td>
        <td></td>
        <td></td>
    </tr>
        <td>48</td>
        <td></td>
        <td></td>
    </tr>
        <td>49</td>
        <td></td>
        <td></td>
    </tr>
        <td>50</td>
        <td></td>
        <td></td>
    </tr>
        <td>51</td>
        <td></td>
        <td></td>
    </tr>
        <td>52</td>
        <td></td>
        <td></td>
    </tr>
        <td>53</td>
        <td></td>
        <td></td>
    </tr>
        <td>54</td>
        <td></td>
        <td></td>
    </tr>
        <td>55</td>
        <td></td>
        <td></td>
    </tr>
        <td>56</td>
        <td></td>
        <td></td>
    </tr>
        <td>57</td>
        <td></td>
        <td></td>
    </tr>
        <td>58</td>
        <td></td>
        <td></td>
    </tr>
        <td>59</td>
        <td></td>
        <td></td>
    </tr>
        <td>60</td>
        <td></td>
        <td></td>
    </tr>
        <td>61</td>
        <td></td>
        <td></td>
    </tr>
        <td>62</td>
        <td></td>
        <td></td>
    </tr>
        <td>63</td>
        <td></td>
        <td></td>
    </tr>
        <td>64</td>
        <td></td>
        <td></td>
    </tr>
        <td>65</td>
        <td></td>
        <td></td>
    </tr>
        <td>66</td>
        <td></td>
        <td></td>
    </tr>
        <td>67</td>
        <td></td>
        <td></td>
    </tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    
</table>





    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>